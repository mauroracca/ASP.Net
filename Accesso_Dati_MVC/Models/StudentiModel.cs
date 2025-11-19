using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesso_Dati_MVC.Models
{
    public class StudentiModel
    {
        private int _matricola;
        private string _cognome;
        private string _nome;
        private DateTime _dataN;
        private int _codCl;
        private string _stage;
        private ClassiModel _classe;

        public int Matricola { get => _matricola; set => _matricola = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public DateTime DataN { get => _dataN; set => _dataN = value; }
        public int CodCl { get => _codCl; set => _codCl = value; }
        public string Stage { get => _stage; set => _stage = value; }
        public ClassiModel Classe { get => _classe; set => _classe = value; }

        public StudentiModel()
        { }
    }

}