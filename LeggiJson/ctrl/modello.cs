using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provaJson.ctrl
{
    public class modello
    {
        private string _user;
        private string _pwd;
        private string _nome;
        private string _cognome;
        private string _dipartimento;

        public string User { get => _user; set => _user = value; }
        public string Pwd { get => _pwd; set => _pwd = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public string Dipartimento { get => _dipartimento; set => _dipartimento = value; }
    }
}