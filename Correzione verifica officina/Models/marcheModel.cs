using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace market.Models
{
    public class marcheModel
    {
        private int idMarca;
        private string nomeMarca;
        private string nazione;
       
        public marcheModel() { }

        public int IdMarca { get => idMarca; set => idMarca = value; }
        public string NomeMarca { get => nomeMarca; set => nomeMarca = value; }
        public string Nazione { get => nazione; set => nazione = value; }
    }
}