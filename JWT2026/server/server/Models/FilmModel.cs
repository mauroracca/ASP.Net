using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class FilmModel
    {
        private int idFilm;
        private string titolo;
        private int anno;
        private int durata;
        private string trama;
        private string locandina;
        private double incasso;
        private int idRegista;
        private int idCategoria;
        private string nomeCategoria;
        private string cognome;
        private string nome;

        public int IdFilm { get => idFilm; set => idFilm = value; }
        public string Titolo { get => titolo; set => titolo = value; }
        public int Anno { get => anno; set => anno = value; }
        public int Durata { get => durata; set => durata = value; }
        public string Trama { get => trama; set => trama = value; }
        public string Locandina { get => locandina; set => locandina = value; }
        public double Incasso { get => incasso; set => incasso = value; }
        public int IdRegista { get => idRegista; set => idRegista = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string NomeCategoria { get => nomeCategoria; set => nomeCategoria = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public string Nome { get => nome; set => nome = value; }
    }
}