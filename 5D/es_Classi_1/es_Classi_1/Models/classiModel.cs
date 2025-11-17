using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace classi.Models
{
    public class classiModel
    {
        private int codCl;
        private string nomeCl;
        private string spec;

        public int CodCl { get => codCl; set => codCl = value; }
        public string NomeCl { get => nomeCl; set => nomeCl = value; }
        public string Spec { get => spec; set => spec = value; }
    }
}