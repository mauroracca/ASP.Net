using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using wsRest.Models;
using System.Web.UI;
using System.Collections.Specialized;
//jwt
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace wsRest.Controllers
{
    public class FumettiController : ApiController
    {
        //Gestione jwt
        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        [HttpGet]
        public bool getHeaders()      // Get the token from the ajax header call letto dall'header della chiamata da localstorage
            /* Codice eventualmente da mettere in web.config nella sezione System.Webserver nel caso non si riuscisse ad accedere all'headers
              <httpProtocol>
                  <customHeaders>
                    <add name="Access-Control-Allow-Origin" value="*" />
                    <add name="Access-Control-Allow-Headers" value="*" />
                    <add name="Access-Control-Allow-Methods" value="GET, POST, PUT, DELETE" />
                  </customHeaders>
              </httpProtocol>
             */ 
        {
            try
            {
                string user = "";
                string tokenType = "";
                string tokenValue = "";
                HttpRequestHeaders h = Request.Headers;
                if (h.Contains("token"))
                {
                    tokenValue = h.GetValues("token").FirstOrDefault();
                    string token = tokenValue.Split(' ')[1];
                    if (token != "null")
                        return ValidateToken(token, out user, out tokenType);
                    else
                        return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]   
        public bool getToken()      // Recupera il token dal cookie e lo valida
        {
            try
            {
                string cookieValue = "";
                string token = "";
                string user = "";
                string tokenType = "";
                CookieHeaderValue cook = Request.Headers.GetCookies("token").FirstOrDefault();
                if (cook != null)
                {
                    cookieValue = cook["token"].ToString();
                    token = cookieValue.Split('=')[1];
                    if (!ValidateToken(token,out user, out tokenType))
                    {
                        return false;
                    }
                }
                else
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        public string setLocalToken()
        {
            try
            {
                var token = GenerateToken("Topolino","tokenLocalStorage", 10);
                return token;
            }
            catch (Exception ex)
            {
                return "KO";
            }
        }

        [HttpGet]
        public HttpResponseMessage setToken()
        {
            var resp = new HttpResponseMessage();
            try
            {
                var token=GenerateToken("Paperino","tokenCookie",1);

                var cookie = new CookieHeaderValue("token", token);
                cookie.Expires = DateTimeOffset.Now.AddHours(1);
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";
                cookie.Secure = true;

                resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
                return resp;
            }catch(Exception ex)
            {
                var cookie = new CookieHeaderValue("session-id", ex.Message);
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";

                resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
                return resp;
            }
        }
        private string GenerateToken(string username, string tokenType, int expireMinutes)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.Now;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]          // payload del token dove posso mettere dentro i dati che mi servono
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Name, tokenType)
                }),

                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var getToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(getToken);

            return token;
        }

        private static bool ValidateToken(string token, out string username, out string tokenType)
        {
            username = null;
            tokenType = null;

            var simplePrinciple = GetPrincipal(token);
            if (simplePrinciple != null)
            {
                var identity = simplePrinciple.Identity as ClaimsIdentity;

                if (identity == null)
                    return false;

                if (!identity.IsAuthenticated)
                    return false;

                Claim[] payloadObjects = identity.Claims.ToArray();
                username = payloadObjects[0].Value;
                tokenType = payloadObjects[1].Value;

                if (string.IsNullOrEmpty(username))
                    return false;

                // More validate here

                return true;
            }
            return false;
        }

        private static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(Secret);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey),
                    ValidateLifetime=true,
                    LifetimeValidator=Validate
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out var securityToken);

                if (!(securityToken is JwtSecurityToken jwtSecurityToken) || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return null;
                }

                return principal;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return null;
            }
        }

        public static bool Validate(DateTime? notBefore, DateTime? expires, SecurityToken tokenToValidate, TokenValidationParameters @param)
        {
            return (expires != null && expires > DateTime.UtcNow);
        }
    }
}
