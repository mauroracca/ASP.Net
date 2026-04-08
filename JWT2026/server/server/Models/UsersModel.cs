using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class UsersModel
    {
        private int idUser;
        private string email;
        private string pwd;
        private string residenza;
        private string regione;

        public int IdUser { get => idUser; set => idUser = value; }
        public string Email { get => email; set => email = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public string Residenza { get => residenza; set => residenza = value; }
        public string Regione { get => regione; set => regione = value; }
    }
}