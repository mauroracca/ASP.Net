using server.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace server.Controllers
{
    public class FilmController : ApiController
    {
        private SqlConnection _cn;
        private SqlCommand _cmd;
        private SqlDataReader _dr;
        private FilmModel film;
        private List<FilmModel> lstFilms;
        private string _connectionString = System.Configuration.ConfigurationManager.AppSettings["connection"];

        private bool IsLogged()
        {
            var authCtrl = new UserController();
            
            return authCtrl.validateTokenApiCall(Request);
        }

        public IEnumerable<FilmModel> GetAllFilms()
        {
            if (!IsLogged())
                return null;
            
            lstFilms = new List<FilmModel>();
            _cn = new SqlConnection(_connectionString);
            _cn.Open();
            _cmd = new SqlCommand();
            _cmd.Connection = _cn;
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = "SELECT film.id_film, film.titolo, film.anno, film.durata, film.trama, film.incasso, film.locandina, registi.nome, registi.cognome, categorie.nome_categoria FROM film INNER JOIN categorie ON film.id_categoria = categorie.id_categoria INNER JOIN registi ON film.id_regista = registi.id_regista";
            _dr = _cmd.ExecuteReader();
            
            while (_dr.Read())
            {
                film = new FilmModel();
                film.IdFilm = Convert.ToInt32(_dr["id_film"]);
                film.Titolo = _dr["titolo"].ToString();
                film.Anno = Convert.ToInt32(_dr["anno"]);
                film.Durata = Convert.ToInt32(_dr["durata"]);
                film.Trama = _dr["trama"].ToString();
                film.Locandina = _dr["locandina"].ToString();
                film.Incasso = Convert.ToDouble(_dr["incasso"]);
                film.Nome= _dr["nome"].ToString();
                film.Cognome = _dr["cognome"].ToString();
                film.NomeCategoria = _dr["nome_categoria"].ToString();
                lstFilms.Add(film);
            }
            _cmd.Dispose();
            _cn.Close();
            _cn.Dispose();
            return lstFilms;
        }

        [HttpPost]
        public FilmModel getSingleFilm([FromBody] FilmModel f)
        {
            film = new FilmModel();

            if (!IsLogged())
            {
                film = null;
                return film;
            }
            _cn = new SqlConnection(_connectionString);
            _cn.Open();
            _cmd = new SqlCommand();
            _cmd.Connection = _cn;
            _cmd.CommandType = CommandType.Text;
            _cmd.Parameters.AddWithValue("@idF", f.IdFilm.ToString());
            _cmd.CommandText = "SELECT * from film INNER JOIN categorie ON film.id_categoria = categorie.id_categoria INNER JOIN registi ON film.id_regista = registi.id_regista where id_film = @idF";
            _dr = _cmd.ExecuteReader();

            while (_dr.Read())
            {
                film.IdFilm = Convert.ToInt32(_dr["id_film"]);
                film.Titolo = _dr["titolo"].ToString();
                film.Anno = Convert.ToInt32(_dr["anno"]);
                film.Durata = Convert.ToInt32(_dr["durata"]);
                film.Trama = _dr["trama"].ToString();
                film.Locandina = _dr["locandina"].ToString();
                film.Incasso = Convert.ToDouble(_dr["incasso"]);
                film.Nome = _dr["nome"].ToString();
                film.Cognome = _dr["cognome"].ToString();
                film.NomeCategoria = _dr["nome_categoria"].ToString();
            }
            _cmd.Dispose();
            _cn.Close();
            _cn.Dispose();
            return film;
        }
    }
}