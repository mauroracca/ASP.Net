using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using GestioneAuto.Models;
using Newtonsoft.Json;

namespace GestioneAuto.Controllers
{
    //[EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]
    public class AutoController : ApiController
    {
        private List<UtentiModel> _lstUtenti;
        private List<AutoModel> _lstAuto;

        public List<UtentiModel> LstUtenti { get => _lstUtenti; set => _lstUtenti = value; }
        public List<AutoModel> LstAuto { get => _lstAuto; set => _lstAuto = value; }

        // GET api/<controller>
        public IEnumerable<UtentiModel> GetAllUtenti()
        {
            _lstUtenti = new List<UtentiModel>();
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.RelativeSearchPath + @"\utenti.json");
            String testoFile = sr.ReadToEnd();
            sr.Close();
            _lstUtenti = JsonConvert.DeserializeObject<List<UtentiModel>>(testoFile);
            return _lstUtenti;
        }

        // GET 
        public IEnumerable<AutoModel> GetAllAuto()
        {
            _lstAuto = new List<AutoModel>();
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.RelativeSearchPath + @"\auto.json");
            String testoFile = sr.ReadToEnd();
            sr.Close();
            _lstAuto = JsonConvert.DeserializeObject<List<AutoModel>>(testoFile);
            return _lstAuto;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        // POST api/<controller>
        public string Post([FromBody] AutoModel dataParam)
        {
            try
            {
                string marca = dataParam.Marca;
                string modello = dataParam.Modello;
                int costo =Convert.ToInt32( dataParam.Costo);
                return "dati ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}