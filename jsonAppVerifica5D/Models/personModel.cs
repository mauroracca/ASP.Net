using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jsonApp.Models
{
    public class personModel
    {
        private string _codice;
        private string _genere;
        private string _nome;
        private string _cognome;
        private string _email;
        private string _citta;
        private string _categoria;
        private string _dataScadenzaContratto;
        private string _pwd;

        public string Codice { get => _codice; set => _codice = value; }
        public string Genere { get => _genere; set => _genere = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public string Email { get => _email; set => _email = value; }
        public string Citta { get => _citta; set => _citta = value; }
        public string Categoria { get => _categoria; set => _categoria = value; }
        public string DataScadenzaContratto { get => _dataScadenzaContratto; set => _dataScadenzaContratto = value; }
        public string Pwd { get => _pwd; set => _pwd = value; }
    }
}