using jsonApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jsonApp.Controllers
{
    public class AutoController : Controller
    {
        private List<autoModel> _lstAuto;// = new List<autoModel>();   

        public List<autoModel> LstAuto { get => _lstAuto; set => _lstAuto = value; }
        public List<autoModel> GetAllAuto()
        {
            LstAuto = new List<autoModel>();
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.RelativeSearchPath + @"\auto.json");
            String testoFile = sr.ReadToEnd();
            sr.Close();
            LstAuto = JsonConvert.DeserializeObject<List<autoModel>>(testoFile);
            return LstAuto;
        }

        public string addAuto(string modello, string marca, string alimentazione, string costo, string categoria, string id)
        {
            string msgInsert = "";
            try
            {
                LstAuto = new List<autoModel>();
                StreamReader sr = new StreamReader(AppDomain.CurrentDomain.RelativeSearchPath + @"\auto.json");
                String testoFile = sr.ReadToEnd();
                sr.Close(); sr.Dispose();
                LstAuto = JsonConvert.DeserializeObject<List<autoModel>>(testoFile);
                autoModel _newAuto = new autoModel();
                _newAuto.Id_auto = id;
                _newAuto.Marca = marca;
                _newAuto.Modello = modello;
                _newAuto.Alimentazione = alimentazione;
                _newAuto.Categoria=categoria;
                _newAuto.Costo = costo;
                LstAuto.Add(_newAuto);
                string nuovoFile = JsonConvert.SerializeObject(LstAuto);
                StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.RelativeSearchPath + @"\auto.json");
                sw.Write(nuovoFile);
                sw.Close(); sw.Dispose();
                msgInsert = "Auto inserita corretamente!";
            }
            catch (Exception ex)
            {
                msgInsert = "Errore durante l'inserimento dei dati! " + ex.Message;
            }
            return msgInsert;
        }
    }
}