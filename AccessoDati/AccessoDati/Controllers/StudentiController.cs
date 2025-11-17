using AccessoDati.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AccessoDati.Controllers
{
    public class StudentiController 
    {
        private String _connectionstring = System.Configuration.ConfigurationManager.AppSettings["connection"];
        //private String _nomeDB = System.Configuration.ConfigurationManager.AppSettings["nomeDB"];
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _dataReader;

        public List<StudentiModel> getAllStudents()
        {
            connetti();
            List<StudentiModel> lstStudenti = new List<StudentiModel>();
            _command.CommandText = "select * from alunni";
            _dataReader = _command.ExecuteReader();
            while (_dataReader.Read())
            {
                StudentiModel stud = new StudentiModel();
                stud.Matricola = Convert.ToInt32(_dataReader["matricola"]);
                stud.Cognome = _dataReader["cognome"].ToString();
                stud.Nome = _dataReader["nome"].ToString();
                stud.DataN = Convert.ToDateTime(_dataReader["dataN"]);
                stud.CodCl = Convert.ToInt32(_dataReader["codCl"]);
                stud.Stage = _dataReader["stage"].ToString();
                lstStudenti.Add(stud);
            }
            disconnetti();
            return lstStudenti;
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