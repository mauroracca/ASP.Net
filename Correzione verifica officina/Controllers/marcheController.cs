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
    public class marcheController : Controller
    {
        private string _connectionstring = System.Configuration.ConfigurationManager.AppSettings["connection"];
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private  List<marcheModel> lstMarche;

        public List<marcheModel> getAllMarche()
        {
            connetti();
            lstMarche = new List<marcheModel>();
            marcheModel marca;
            _command.CommandText = "select * from MarcheAuto";
            _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                marca = new marcheModel();
                marca.IdMarca = Convert.ToInt32(_reader["IdMarca"]);
                marca.NomeMarca = _reader["NomeMarca"].ToString();
                marca.Nazione = _reader["Nazione"].ToString();
                lstMarche.Add(marca);
            }
            disconnetti();
            return lstMarche;
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