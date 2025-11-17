using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccessoDati.Models
{
    public class StudentiModel
    {
        private int matricola;
        private string cognome;
        private string nome;
        private DateTime dataN;
        private int codCl;
        private string stage;

        public StudentiModel()
        {
        }

        public int Matricola { get => matricola; set => matricola = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public string Nome { get => nome; set => nome = value; }
        public DateTime DataN { get => dataN; set => dataN = value; }
        public int CodCl { get => codCl; set => codCl = value; }
        public string Stage { get => stage; set => stage = value; }
    }
}