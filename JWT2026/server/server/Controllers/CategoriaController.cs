using server.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace server.Controllers
{
    public class CategoriaController : ApiController
    {
        private SqlConnection _cn;
        private SqlCommand _cmd;
        private SqlDataReader _dr;
        private CategoriaModel categoria;
        private string _connectionString = System.Configuration.ConfigurationManager.AppSettings["connection"];

        private bool IsLogged()
        {
            var session = HttpContext.Current.Session;

            return session != null && session["emailUser"] != null;
            //return true;
        }

        [HttpPost]
        public CategoriaModel getCategoria([FromBody] FilmModel f)
        {
            if (!IsLogged())
            {
                return null;
            }
            categoria = new CategoriaModel();
            try
            {
                _cn = new SqlConnection(_connectionString);
                _cn.Open();
                _cmd = new SqlCommand();
                _cmd.Connection = _cn;
                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.AddWithValue("@nomeCat", f.NomeCategoria.ToString());
                _cmd.CommandText = "SELECT * from categorie where nome_categoria = @nomeCat";
                _dr = _cmd.ExecuteReader();
                while (_dr.Read())
                {
                    categoria.IdCat = Convert.ToInt32(_dr["id_categoria"]);
                    categoria.NomeCat = _dr["nome_categoria"].ToString();
                    categoria.DescrizioneCat = _dr["descrizione"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_cn != null)
                {
                    _cn.Close();
                }
            }
            return categoria;
        }

        [HttpPost]
        public int getIncasso([FromBody] FilmModel f)
        {
            int incassoTot = 0;
            if (!IsLogged())
            {
                return incassoTot;
            }
            try
            {
                _cn = new SqlConnection(_connectionString);
                _cn.Open();
                _cmd = new SqlCommand();
                _cmd.Connection = _cn;
                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.AddWithValue("@idCat", f.IdCategoria);
                _cmd.CommandText = "SELECT SUM(incasso) from film where id_categoria = @idCat";
                object result = _cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    incassoTot = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (_cn != null)
                {
                    _cn.Close();
                }
            }
            return incassoTot;
        }
    }
}