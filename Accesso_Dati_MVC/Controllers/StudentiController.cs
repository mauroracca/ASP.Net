using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Accesso_Dati_MVC.Models;

namespace Accesso_Dati_MVC.Controllers
{
    public class StudentiController
    {
        private string _connectionstring = System.Configuration.ConfigurationManager.AppSettings["connection"];
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private StudentiModel _stud;

        private List<StudentiModel> _lstStudenti;

        private ClassiController _ctrlClassi=new ClassiController();
        public List<StudentiModel> getAllStudenti()
        {
            connetti();
            _lstStudenti = new List<StudentiModel>();
            _command.CommandText = "select * from alunni";
            _reader=_command.ExecuteReader();
            while (_reader.Read())
            {
                _stud = new StudentiModel();
                _stud.Matricola = Convert.ToInt32(_reader["matricola"]);
                _stud.Cognome = _reader["cognome"].ToString();
                _stud.Nome = _reader["nome"].ToString();
                _stud.DataN = Convert.ToDateTime(_reader["dataN"]);
                _stud.CodCl = Convert.ToInt32(_reader["codCl"]);
                _stud.Stage = _reader["stage"].ToString();
                _lstStudenti.Add(_stud);
            }
            return _lstStudenti;
        }
        
        public StudentiModel getStudente(int matricola)
        {
            connetti();
            _stud = new StudentiModel();
            _command.Parameters.AddWithValue("@matricola",matricola);
            _command.CommandText = "select * from alunni where matricola=@matricola";
            _reader=_command.ExecuteReader();
            while (_reader.Read())
            {
                _stud.Matricola = Convert.ToInt32(_reader["matricola"]);
                _stud.Cognome = _reader["cognome"].ToString();
                _stud.Nome = _reader["nome"].ToString();
                _stud.DataN = Convert.ToDateTime(_reader["dataN"]);
                _stud.CodCl = Convert.ToInt32(_reader["codCl"]);
                _stud.Stage = _reader["stage"].ToString();
                _stud.Classe= _ctrlClassi.getClasse(_stud.CodCl);
            }
            disconnetti();
            return _stud;
        }
        public void createStudente(int m, string c, string n, DateTime d, int cl, string s)
        {
            connetti();
            _command.Parameters.AddWithValue("@matricola", m);
            _command.Parameters.AddWithValue("@cognome", c);
            _command.Parameters.AddWithValue("@nome", n);
            _command.Parameters.AddWithValue("@dataN", d);
            _command.Parameters.AddWithValue("@codCl", cl);
            _command.Parameters.AddWithValue("@stage", s);
            _command.CommandText = "INSERT INTO alunni VALUES (@matricola,@cognome,@nome,@dataN,@codCl,@stage)";
            _command.ExecuteNonQuery();
            disconnetti();
        }

        public void updateStudente(int m, string c, string n, DateTime d, int cl, string s)
        {
            connetti();
            _command.Parameters.AddWithValue("@matricola", m);
            _command.Parameters.AddWithValue("@cognome", c);
            _command.Parameters.AddWithValue("@nome", n);
            _command.Parameters.AddWithValue("@dataN", d);
            _command.Parameters.AddWithValue("@codCl", cl);
            _command.Parameters.AddWithValue("@stage", s);
            _command.CommandText = "UPDATE alunni " +
                                   "SET cognome=@cognome, " +
                                   "nome=@nome, " +
                                   "dataN=@dataN, " +
                                   "codCl=@codCl, " +
                                   "stage=@stage " +
                                   "WHERE matricola=@matricola";
            _command.ExecuteNonQuery();
            disconnetti();
        }

        public void deleteStdente(int m)
        {
            connetti();
            _command.Parameters.AddWithValue("@matricola", m);
            _command.CommandText = "DELETE FROM alunni " +
                                    "WHERE matricola=@matricola";
            _command.ExecuteNonQuery();
            disconnetti();
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