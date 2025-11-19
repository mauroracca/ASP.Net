using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Accesso_Dati_MVC.Models;

namespace Accesso_Dati_MVC.Controllers
{
    public class ClassiController
    {
        private string _connectionstring = System.Configuration.ConfigurationManager.AppSettings["connection"];
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        private ClassiModel _classe;

        public ClassiModel getClasse(int id)
        {
            connetti();
            _classe = new ClassiModel();
            _command.Parameters.AddWithValue("@id", id);
            _command.CommandText = "select * from classi where codCl=@id";
            _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                _classe.CodCl = Convert.ToInt32(_reader["codCl"]);
                _classe.NomeCl = _reader["nomeCl"].ToString();
                _classe.Spec = _reader["spec"].ToString();
            }
            disconnetti();
            return _classe;
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
    }
}