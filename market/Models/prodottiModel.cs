using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace market.Models
{
    public class prodottiModel
    {
        private int idProdotto;
        private string nomeProdotto;
        private string descrizione;
        private double prezzo;
        private int quantita;
        private int idV;

        public prodottiModel() { }

        public int IdProdotto { get => idProdotto; set => idProdotto = value; }
        public string NomeProdotto { get => nomeProdotto; set => nomeProdotto = value; }
        public string Descrizione { get => descrizione; set => descrizione = value; }
        public double Prezzo { get => prezzo; set => prezzo = value; }
        public int Quantita { get => quantita; set => quantita = value; }
        public int IdV { get => idV; set => idV = value; }
    }
}