using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace market.Models
{
    public class userModel
    {
        private int _id;
        private string nome;
        private string cognome;
        private string email;
        private string password;
        private string indirizzo;

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Indirizzo { get => indirizzo; set => indirizzo = value; }

        public userModel() { }
    }
}