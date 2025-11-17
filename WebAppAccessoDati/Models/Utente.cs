using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppAccessoDati.Models
{
    public class Utente
    {
        private int _id;
        private string _user;
        private string _password;

        public int Id { get => _id; set => _id = value; }
        public string User { get => _user; set => _user = value; }
        public string Password { get => _password; set => _password = value; }
    }
}