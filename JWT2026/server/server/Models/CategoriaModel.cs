using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class CategoriaModel
    {
        private int idCat;
        private string nomeCat;
        private string descrizioneCat;

        public int IdCat { get => idCat; set => idCat = value; }
        public string NomeCat { get => nomeCat; set => nomeCat = value; }
        public string DescrizioneCat { get => descrizioneCat; set => descrizioneCat = value; }
    }
}