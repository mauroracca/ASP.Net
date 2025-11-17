using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using AccessoDati.Models;
using System.EnterpriseServices;

namespace AccessoDati.Controllers
{
    public class UserController
    {
        private String _connectionstring = System.Configuration.ConfigurationManager.AppSettings["connection"];
        //private String _nomeDB = System.Configuration.ConfigurationManager.AppSettings["nomeDB"];
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _dataReader;

        public bool login(string u, string p)
        {
            bool loginOk = false;
            connetti();
            _command.Parameters.AddWithValue("@user", u);
            _command.CommandText = "select * from Utenti where username = @user";
            _dataReader = _command.ExecuteReader();
            while (_dataReader.Read())
            {
                string str = _dataReader["password"].ToString();
                if (_dataReader["password"].ToString().Trim() == p)
                    loginOk = true;
            }
            disconnetti();
            return loginOk;
        }
       
        public List<UserModel> getAllUsers()
        {
            connetti();
            List<UserModel> lstUsers= new List<UserModel>();
            _command.CommandText = "select * from Utenti";
            _dataReader = _command.ExecuteReader();
            while (_dataReader.Read())
            {
                UserModel user = new UserModel();
                user.Id = Convert.ToInt32(_dataReader["Id"]);
                user.User = _dataReader["username"].ToString();
                user.Password = _dataReader["password"].ToString();
                lstUsers.Add(user);
            }
            disconnetti();
            return lstUsers;
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