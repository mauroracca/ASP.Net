using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace market.Models
{
    public class riparazioniModel
    {
        private int idRiparazione;
        private int idMarca;
        private string modello;
        private string targa;
        private string descrizione;
        private bool terminato;
        private bool pagato;
        private DateTime dataStart;

        public riparazioniModel() { }

        public int IdRiparazione { get => idRiparazione; set => idRiparazione = value; }
        public int IdMarca { get => idMarca; set => idMarca = value; }
        public string Modello { get => modello; set => modello = value; }
        public string Targa { get => targa; set => targa = value; }
        public string Descrizione { get => descrizione; set => descrizione = value; }
        public bool Terminato { get => terminato; set => terminato = value; }
        public bool Pagato { get => pagato; set => pagato = value; }
        public DateTime DataStart { get => dataStart; set => dataStart = value; }
    }
}