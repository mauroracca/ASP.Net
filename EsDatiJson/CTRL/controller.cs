using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EsDatiJson.CTRL
{
    public class controller
    {
        private modello _cityModel;
        private List<modello> _lstJsonCity;
        public controller() { }

        public List<modello> GetAllCity()
        {
            _lstJsonCity = new List<modello>();
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.RelativeSearchPath+@"\italy.json");
            string testoFile = sr.ReadToEnd();
            sr.Close(); sr.Dispose();
            _lstJsonCity = JsonConvert.DeserializeObject<List<modello>>(testoFile);
            return _lstJsonCity;
        }
    }
}