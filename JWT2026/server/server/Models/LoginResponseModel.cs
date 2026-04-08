using System;

namespace server.Models
{
    public class LoginResponseModel
    {
        //public bool Success { get; set; }
        //public string Token { get; set; }
        //public string Message { get; set; }
        //public UsersModel User { get; set; }
        private bool success;
        private string token;
        private string message;
        private UsersModel user;

        public bool Success { get => success; set => success = value; }
        public string Token { get => token; set => token = value; }
        public string Message { get => message; set => message = value; }
        public UsersModel User { get => user; set => user = value; }
    }
}

