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
    public class UserController : Controller
    {
        private string _connectionstring = System.Configuration.ConfigurationManager.AppSettings["connection"];
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private userModel _user;

        public userModel userLogin(int id, string pwd)
        {
            connetti();
            bool autenticato = false;
            _command.Parameters.AddWithValue("@user", id);
            _command.Parameters.AddWithValue("@pwd", pwd);
            _command.CommandText = "SELECT * FROM utenti WHERE IdUtente=@user";
            _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                if(_reader["PasswordHash"].ToString() == pwd)
                {
                    _user = new userModel();
                    _user.Id = Convert.ToInt32(_reader["IdUtente"]);
                    _user.Cognome = _reader["Cognome"].ToString();
                    _user.Nome = _reader["Nome"].ToString();
                    _user.Email = _reader["Email"].ToString();
                    _user.Password = _reader["PasswordHash"].ToString();
                    _user.Indirizzo = _reader["Indirizzo"].ToString();
                    autenticato = true;
                }
            }            
            disconnetti();
            if (autenticato)
                return _user;
            else
                return null;
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