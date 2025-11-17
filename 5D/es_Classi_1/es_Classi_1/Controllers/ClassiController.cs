using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using classi.Models;

namespace es_Classi.Controllers
{
    public class ClassiController : ApiController
    {
        private SqlConnection _cn;
        private SqlCommand _cmd;
        private SqlDataReader _dr;
        private classiModel cls;
        private List<classiModel> lstClassi;
        private string _connectionString = System.Configuration.ConfigurationManager.AppSettings["connection"];

       
        public IEnumerable<classiModel> GetAllClassi()
        {   
            connetti();
            _cmd.CommandText = "select * from classi";
            _dr = _cmd.ExecuteReader();
            lstClassi = new List<classiModel>();
            while (_dr.Read())
            {
                cls = new classiModel();
                cls.CodCl = Convert.ToInt32(_dr["codCl"]);
                cls.NomeCl = _dr["nomeCl"].ToString();
                cls.Spec = _dr["spec"].ToString();
                lstClassi.Add(cls);
            }
            disconnetti();
            return lstClassi;
        }
        private void connetti()
        {
            _cn = new SqlConnection(_connectionString);
            _cn.Open();
            _cmd = new SqlCommand();
            _cmd.Connection = _cn;
            _cmd.CommandType = CommandType.Text;
        }

        private void disconnetti()
        {
            _cmd.Dispose();
            _cn.Close();
            _cn.Dispose();
        }
    }
}