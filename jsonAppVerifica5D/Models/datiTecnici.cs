using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jsonApp.Models
{
    public class datiTecnici
    {
        private int potenza;
        private int consumi;

        public int Potenza { get => potenza; set => potenza = value; }
        public int Consumi { get => consumi; set => consumi = value; }
    }
}