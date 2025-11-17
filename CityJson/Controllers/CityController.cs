using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CityJson.Models;
using Newtonsoft.Json;

namespace CityJson.Controllers
{
    public class CityController : Controller
    {
        private cityJson _cityJson;
        private List<cityJson> _lstJsonCity;
        public List<cityJson> CityJson { get { return _lstJsonCity; } }

        public List<cityJson> GetAllCity() {
            _lstJsonCity = new List<cityJson>();
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.RelativeSearchPath + @"\italy.json");
            String testoFile = sr.ReadToEnd();
            sr.Close(); 
            _lstJsonCity=JsonConvert.DeserializeObject<List<cityJson>>(testoFile);
            return _lstJsonCity; 
        } 
    }
}