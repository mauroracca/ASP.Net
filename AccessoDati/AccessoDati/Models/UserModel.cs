using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccessoDati.Models
{
    public class UserModel
    {
        private int id;
        private string user;
        private string password;

        public UserModel()
        {
        }

        public int Id { get => id; set => id = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
    }
}