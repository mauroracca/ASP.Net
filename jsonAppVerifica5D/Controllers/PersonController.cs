using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jsonApp.Models;
using Newtonsoft.Json;

namespace jsonApp.Controllers
{
    public class PersonController : Controller
    {
        private List<personModel> _lstPerson;// = new List<personModel>();

        public List<personModel> LstPerson { get => _lstPerson; set => _lstPerson = value; }

        public List<personModel> GetAllPerson()
        {
            LstPerson = new List<personModel>();
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.RelativeSearchPath + @"\utenti.json");
            String testoFile = sr.ReadToEnd();
            sr.Close();
            LstPerson = JsonConvert.DeserializeObject<List<personModel>>(testoFile);
            return LstPerson;
        }
    }
}