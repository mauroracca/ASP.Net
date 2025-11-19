using market.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace market.Controllers
{
    public class ProdottiController : Controller
    {
        private string _connectionstring = System.Configuration.ConfigurationManager.AppSettings["connection"];
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private  List<prodottiModel> lstProdotti;

        public List<prodottiModel> getAllProdotti()
        {
            connetti();
            lstProdotti = new List<prodottiModel>();
            prodottiModel prod;
            _command.CommandText = "select * from Prodotti";
            _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                prod = new prodottiModel();
                prod.IdProdotto = Convert.ToInt32(_reader["IdProdotto"]);
                prod.NomeProdotto = _reader["Nome"].ToString();
                prod.Descrizione = _reader["Descrizione"].ToString();
                prod.Prezzo = Convert.ToDouble(_reader["Prezzo"]);
                prod.Quantita = Convert.ToInt32(_reader["QuantitaDisponibile"]);
                prod.IdV=Convert.ToInt32(_reader["IdVenditore"]);
                lstProdotti.Add(prod);
            }
            disconnetti();
            return lstProdotti;
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

        // GET: Prodotti
        public ActionResult Index()
        {
            return View();
        }
    }
}