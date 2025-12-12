using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using market.Models;

namespace market.Controllers
{
    public class riparazioniController : Controller
    {
        private string _connectionstring = System.Configuration.ConfigurationManager.AppSettings["connection"];
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private riparazioniModel riparazione;
        private List<riparazioniModel> lstRiparazioni;

        public List<riparazioniModel> getRipXmarca(string marca)
        {
            connetti();
            lstRiparazioni=new List<riparazioniModel>();
            _command.Parameters.AddWithValue("@marca",marca);
            _command.CommandText = "SELECT * FROM Riparazioni WHERE IdMarca=@marca";
            _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                riparazione = new riparazioniModel();
                riparazione.IdRiparazione = Convert.ToInt32(_reader["IdRiparazione"]);
                riparazione.Modello = _reader["Modello"].ToString();
                riparazione.Targa = _reader["Targa"].ToString();
                riparazione.Descrizione = _reader["Descrizione"].ToString();
                riparazione.Terminato = (bool)_reader["Terminato"];
                riparazione.Pagato = (bool)_reader["Pagato"];
                riparazione.DataStart = Convert.ToDateTime(_reader["DataIngresso"]);
                lstRiparazioni.Add(riparazione);
            }
            disconnetti();
            return lstRiparazioni;
        }

        public bool modificaRiparazione(int idRip, string modello, string targa, string descrizione, bool terminato, bool pagato)
        {
            try
            {
                connetti();
                _command.Parameters.AddWithValue("@idRip", idRip);
                _command.Parameters.AddWithValue("@modello", modello);
                _command.Parameters.AddWithValue("@targa", targa);
                _command.Parameters.AddWithValue("@descrizione", descrizione);
                _command.Parameters.AddWithValue("@terminato", terminato);
                _command.Parameters.AddWithValue("@pagato", pagato);
                _command.CommandText = "UPDATE Riparazioni SET Modello=@modello, Targa=@targa, Descrizione=@descrizione, Terminato=@terminato, Pagato=@pagato WHERE IdRiparazione=@idRip";
                int rows = _command.ExecuteNonQuery();
                disconnetti();
                return rows > 0;
            }
            catch (Exception ex)
            {
                // Gestione dell'eccezione (ad esempio, log dell'errore)
                return false;
            }
        }

        private void connetti()
        {
            _connection = new SqlConnection(_connectionstring);
            _connection.Open();
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandType = CommandType.Text;
        }

        private void disconnetti()
        {
            _command.Dispose();
            _connection.Close();
            _connection.Dispose();
        }




        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}