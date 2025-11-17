using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace provaJson.ctrl
{
    public class control
    {
        private modello _users;
        private List<modello> _lstJsonUsers;
        
        public List<modello> lstJsonUsers
        {
            get { return _lstJsonUsers; }
        }
        public control() { }
        public List<modello> GetAllUsers()
        {
            _lstJsonUsers = new List<modello>();


            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.RelativeSearchPath + @"\users.json");
            String testoFile = sr.ReadToEnd();
            sr.Close(); sr.Dispose();
            _lstJsonUsers = JsonConvert.DeserializeObject<List<modello>>(testoFile);
            return _lstJsonUsers;
        }

        //public void addCity(string city, string name,int ab, int sup)
        //{
        //    modello m = new modello();
        //    m.city = city;
        //    m.name = name;
        //    _lstJsonCity = new List<modello>();

        //    StreamReader sr = new StreamReader(AppDomain.CurrentDomain.RelativeSearchPath + @"\italy.json");
        //    String testoFile = sr.ReadToEnd();
        //    sr.Close(); sr.Dispose();
        //    _lstJsonCity = JsonConvert.DeserializeObject<List<modello>>(testoFile);
        //    _lstJsonCity.Add(m);
        //    string jsonAggiornato = JsonConvert.SerializeObject(_lstJsonCity);
        //    //Salvataggio dei dati su file
        //    StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.RelativeSearchPath + @"\italy.json");
        //    sw.Write(jsonAggiornato);
        //    sw.Close();
        //}
    }
}