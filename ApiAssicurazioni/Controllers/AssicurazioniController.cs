using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using apiFumetti22.Models;

namespace apiFumetti22.Controllers
{
    public class AssicurazioniController : ApiController
    {
        private SqlConnection _cn;
        private SqlCommand _cmd;
        private SqlDataReader _dr;
        private assicurazioniModel assicurazione;
        private List<assicurazioniModel> lstAssicurazioni;
        private string _connectionString = System.Configuration.ConfigurationManager.AppSettings["connection"];

        // GET api/<controller>
        public IEnumerable<assicurazioniModel> GetAllAssicurazioni()
        {
            _cn = new SqlConnection(_connectionString);
            _cn.Open();
            _cmd = new SqlCommand();
            _cmd.Connection = _cn;
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = "Select * from sedi";
            _dr = _cmd.ExecuteReader();
            lstAssicurazioni = new List<assicurazioniModel>();
            while (_dr.Read())
            {
                assicurazione = new assicurazioniModel();
                assicurazione.CittaSede = _dr["Citta"].ToString();
                assicurazione.CodSede = _dr["codiceSede"].ToString();
                assicurazione.NomeSede = _dr["NomeSede"].ToString();
                assicurazione.ResponsabileSede = _dr["Responsabile"].ToString();
                assicurazione.CodTipoAssicurazione = _dr["CodiceAssicurazione"].ToString();
                lstAssicurazioni.Add(assicurazione);
            }
            _cmd.Dispose();
            _cn.Close();
            _cn.Dispose();
            return lstAssicurazioni;
        }

        [HttpGet]
        // GET api/<controller>/5
        public assicurazioniModel RicercaAssicurazioneGet(string p1)
        {
            _cn = new SqlConnection(_connectionString);
            _cn.Open(); 
            _cmd = new SqlCommand();
            _cmd.Connection = _cn;
            _cmd.CommandType = CommandType.Text;
            _cmd.Parameters.AddWithValue("@assicurazione", p1);
            _cmd.CommandText = "select * from sedi where codiceSede='" + p1 + "'";
            _dr = _cmd.ExecuteReader();
            while (_dr.Read())
            {
                assicurazione = new assicurazioniModel();
                assicurazione.CodSede = _dr["codiceSede"].ToString();
                assicurazione.NomeSede = _dr["NomeSede"].ToString();
                assicurazione.ResponsabileSede = _dr["Responsabile"].ToString();
                assicurazione.CittaSede = _dr["Citta"].ToString();
                assicurazione.CodTipoAssicurazione = _dr["CodiceAssicurazione"].ToString();
            }
            return assicurazione;
        }

        [HttpGet]
        // GET api/<controller>/5/10
        public IEnumerable<assicurazioniModel> RicercaAssicurazioneGet(string p1, string p2)
        {
            _cn = new SqlConnection(_connectionString);
            _cn.Open();
            _cmd = new SqlCommand();
            _cmd.Connection = _cn;
            _cmd.CommandType = CommandType.Text;
            _cmd.Parameters.AddWithValue("@citta", p1);
            _cmd.Parameters.AddWithValue("@tipoAssicurazione", p2);
            _cmd.CommandText = "select * from sedi where Citta='" + p1 + "' and CodiceAssicurazione='"+p2+"'";
            _dr = _cmd.ExecuteReader();
            lstAssicurazioni = new List<assicurazioniModel>();
            while (_dr.Read())
            {
                assicurazione = new assicurazioniModel();
                assicurazione.CodSede = _dr["codiceSede"].ToString();
                assicurazione.NomeSede = _dr["NomeSede"].ToString();
                assicurazione.ResponsabileSede = _dr["Responsabile"].ToString();
                assicurazione.CittaSede = _dr["Citta"].ToString();
                assicurazione.CodTipoAssicurazione = _dr["CodiceAssicurazione"].ToString();
                lstAssicurazioni.Add(assicurazione);
            }
            return lstAssicurazioni;
        }

        [HttpPost]
        public string insert([FromBody] dynamic data)
        {
            try
            {
                string codSede = data.id;
                string nome = data.nome;
                string resp = data.resp;
                string citta = data.citta;
                string tipo = data.tipo;
                _cn = new SqlConnection(_connectionString);
                _cn.Open();
                _cmd = new SqlCommand();
                _cmd.Connection = _cn;
                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.AddWithValue("@cod", codSede);
                _cmd.Parameters.AddWithValue("@nome", nome);
                _cmd.Parameters.AddWithValue("@resp", resp);
                _cmd.Parameters.AddWithValue("@citta", citta);
                _cmd.Parameters.AddWithValue("@tipo", tipo);
                _cmd.CommandText = "insert into sedi (codiceSede, NomeSede, Responsabile, Citta, CodiceAssicurazione) values (@cod, @nome, @resp, @citta, @tipo)";
                _cmd.ExecuteNonQuery();
                return ("Inserimento avvenuto con successo");
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }

        // POST api/<controller>
        public assicurazioniModel RicercaAssicurazione([FromBody] assicurazioniModel data)
        {
            string p1 = data.CodSede;
            _cn = new SqlConnection(_connectionString);
            _cn.Open();
            _cmd = new SqlCommand();
            _cmd.Connection = _cn;
            _cmd.CommandType = CommandType.Text;
            _cmd.Parameters.AddWithValue("@assicurazione", p1);
            _cmd.CommandText = "select * from sedi where codiceSede='" + p1 + "'";
            _dr = _cmd.ExecuteReader();
            while (_dr.Read())
            {
                assicurazione = new  assicurazioniModel();
                assicurazione.CodSede = _dr["codiceSede"].ToString();
                assicurazione.NomeSede= _dr["NomeSede"].ToString();
                assicurazione.ResponsabileSede = _dr["Responsabile"].ToString();
                assicurazione.CittaSede = _dr["Citta"].ToString();
                assicurazione.CodTipoAssicurazione = _dr["CodiceAssicurazione"].ToString();
            }
            return assicurazione;
        }
    }
}