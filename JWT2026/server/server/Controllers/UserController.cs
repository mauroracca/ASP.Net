using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using server.Models;
using System.Web;
using System.Data;
using System.Data.SqlClient;
// JWT - Installare anche il pacchetto nuget "System.IdentityModel.Tokens.Jwt" per gestire i token JWT
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace server.Controllers
{
    public class UserController : ApiController
    {
        private SqlConnection _cn;
        private SqlCommand _cmd;
        private SqlDataReader _dr;
        private UsersModel user;
        private string _connectionString = System.Configuration.ConfigurationManager.AppSettings["connection"];

        // Chiave segreta JWT letta da Web.config
        private static readonly string JwtSecret = System.Configuration.ConfigurationManager.AppSettings["JwtSecret"];
        private static readonly double JwtExpireMinutes = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["JwtExpireMinutes"] ?? "60");

        /// <summary>
        /// POST api/User/login
        /// Autentica l'utente sul database e restituisce un token JWT se le credenziali sono corrette.
        /// Body JSON: { "email": "...", "pwd": "..." }
        /// </summary>
        [HttpPost]
        public LoginResponseModel login([FromBody] UsersModel u)
        {
            try
            {
                _cn = new SqlConnection(_connectionString);
                _cn.Open();
                _cmd = new SqlCommand();
                _cmd.Connection = _cn;
                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.AddWithValue("@email", u.Email.ToString());
                _cmd.CommandText = "SELECT * FROM users WHERE email = @email";
                _dr = _cmd.ExecuteReader();
                user = null;

                while (_dr.Read())
                {
                    if (_dr["pwd"].ToString() == u.Pwd.ToString())
                    {
                        user = new UsersModel();
                        user.IdUser = Convert.ToInt32(_dr["id_user"]);
                        user.Email = _dr["email"].ToString();
                        user.Pwd = _dr["pwd"].ToString();
                        user.Residenza = _dr["residenza"].ToString();
                        user.Regione = _dr["regione"].ToString();
                    }
                }

                _cmd.Dispose();
                _cn.Close();
                _cn.Dispose();

                if (user == null)
                {
                    return new LoginResponseModel
                    {
                        Success = false,
                        Message = "Credenziali non valide",
                        Token = null,
                        User = null
                    };
                }

                // Genera il token JWT
                string token = GenerateToken(user);

                return new LoginResponseModel
                {
                    Success = true,
                    Message = "Login effettuato con successo",
                    Token = token,
                    User = user
                };
            }
            catch (Exception ex)
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Message = "Errore: " + ex.Message,
                    Token = null,
                    User = null
                };
            }
        }

        /// <summary>
        /// GET api/User/validateToken
        /// Valida il token JWT passato nell'header "Authorization: Bearer <token>"
        /// </summary>
        [HttpGet]
        public IHttpActionResult validateToken()
        {
            try
            {
                string authHeader = null;
                if (Request.Headers.Contains("Authorization"))
                    authHeader = Request.Headers.GetValues("Authorization").FirstOrDefault();

                if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                    return Unauthorized();

                string token = authHeader.Substring("Bearer ".Length).Trim();

                UsersModel userLogged;
                if (ValidateToken(token, out userLogged))
                    return Ok(new { valid = true, user = userLogged.Email });

                return Unauthorized();
            }
            catch
            {
                return Unauthorized();
            }
        }

        /// <summary>
        /// GET api/User/validateUserLogged
        /// Controlla se l'utente è autenticato controllando il token JWT ad ogni chiamata 
        /// verso un'api server (il client deve inviare il token nell'header)
        /// </summary>
        [HttpGet]
        public bool validateTokenApiCall(HttpRequestMessage Req)
        {
            try
            {
                string authHeader = null;
                if (Req.Headers.Contains("Authorization"))
                    authHeader = Req.Headers.GetValues("Authorization").FirstOrDefault();

                if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                    return false;

                string token = authHeader.Substring("Bearer ".Length).Trim();

                UsersModel userLogged;
                if (ValidateToken(token, out userLogged))
                {
                    GenerateToken(userLogged);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// GET api/User/logout
        /// Invalida lato client il token (il client deve eliminare il token dal proprio storage).
        /// </summary>
        [HttpGet]
        public IHttpActionResult logout()
        {
            // Con JWT il logout avviene lato client eliminando il token.
            // Qui restituiamo solo conferma.
            return Ok(new { message = "Logout effettuato. Elimina il token dal client." });
        }

        // ────────────────────────────────────────────────────────────────────────
        // METODI PRIVATI JWT
        // ────────────────────────────────────────────────────────────────────────

        private string GenerateToken(UsersModel u)
        {
            var symmetricKey = Convert.FromBase64String(JwtSecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, u.IdUser.ToString()),
                    new Claim(ClaimTypes.Email, u.Email),
                    new Claim("residenza", u.Residenza ?? ""),
                    new Claim("regione", u.Regione ?? "")
                }),
                Expires = now.AddMinutes(JwtExpireMinutes),
                IssuedAt = now,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }

        private bool ValidateToken(string token, out UsersModel user)
        {
            user = new UsersModel();
            try
            {
                var symmetricKey = Convert.FromBase64String(JwtSecret);
                var tokenHandler = new JwtSecurityTokenHandler();

                var validationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out var securityToken);

                if (!(securityToken is JwtSecurityToken jwtToken) ||
                    !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    return false;

                user.Email = principal.FindFirst(ClaimTypes.Email)?.Value;
                user.IdUser = Convert.ToInt32(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                user.Residenza = principal.FindFirst("residenza")?.Value;
                user.Regione = principal.FindFirst("regione")?.Value;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}