using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesso_Dati_MVC.Models
{
    public class ClassiModel
    {
        private int _codCl;
        private string _nomeCl;
        private string _spec;
        private List<StudentiModel> _lstStudenti;

        public int CodCl { get => _codCl; set => _codCl = value; }
        public string NomeCl { get => _nomeCl; set => _nomeCl = value; }
        public string Spec { get => _spec; set => _spec = value; }
        public List<StudentiModel> LstStudenti { get => _lstStudenti; set => _lstStudenti = value; }
    }
}