using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace alunni.Models
{
    public class alunniModel
    {
        private int matricola;
        private string cognome;
        private string nome;
        private DateTime dataN;
        private int codCl;
        private bool stage;

        public int Matricola { get => matricola; set => matricola = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public string Nome { get => nome; set => nome = value; }
        public DateTime DataN { get => dataN; set => dataN = value; }
        public int CodCl { get => codCl; set => codCl = value; }
        public bool Stage { get => stage; set => stage = value; }
    }
}
