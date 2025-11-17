using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using WebAppAccessoDati.Models;

namespace WebAppAccessoDati.Controllers
{
    public class DBController : ApiController
    {
        private String _connectionstring = System.Configuration.ConfigurationManager.AppSettings["connection"];
        private String _nomeDB = System.Configuration.ConfigurationManager.AppSettings["nomeDB"];
        private SqlConnection _connection;
        private SqlCommand _command;

        //disconnessa
        private SqlDataAdapter _adapter;
        private DataTable _dataTable;
        //in alternativa connessa
        private SqlDataReader _dataReader;

        private Utente _ut;
        private List<Utente> _lstUtente;

        // GET api/<controller>
        public IEnumerable<Utente> Get()     // modalità connessa
        {
            connetti();
            _command.CommandText = "select * from Utenti";

            //2° alternativa connessa

            _dataReader=_command.ExecuteReader();
            _ut = new Utente();           
            while(_dataReader.Read())
            {
                _ut.Id =Convert.ToInt32(_dataReader["Id"]);
                _ut.User = _dataReader["user"].ToString();
                _ut.Password = _dataReader["password"].ToString();
                _lstUtente.Add(_ut);
            }

            return _lstUtente;
        }

        public int getInt()
        {
            int numUtenti;
            connetti();
            _command.CommandText = "SELECT COUNT(*) FROM Utenti where sesso = 'F'";

            object objNum = _command.ExecuteScalar();
            numUtenti = Convert.ToInt32(objNum);
            return numUtenti;
        }

        [HttpPost]
        // POST api/<controller>
        public string InsertUser([FromBody] Utente dataParam)
        {
            try
            {
                string user = dataParam.User.ToString();
                string pwd = dataParam.Password.ToString();
                connetti();

                _command.Parameters.AddWithValue("@user", user);
                _command.Parameters.AddWithValue("@pwd", pwd);

                _command.CommandText = "Insert into utenti (user, password) values (@user, @pwd)";
                _command.ExecuteNonQuery();
                return "Inserimento avvenuto con successo";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DataTable GetDis()   // modalità disconnessa
        {
            connetti();
            _command.CommandText = "select * from Utenti";

            //1° alternativa: modalità disconnessa
            _adapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _adapter.Fill(_dataTable);


            return _dataTable;
        }

        private void connetti()
        {
            //_nomeDB= HttpContext.Current.Server.MapPath(_nomeDB);
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
    }
}