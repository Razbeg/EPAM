using System;
using System.Collections.Generic;
using System.Text;

namespace Task10.Model
{
    public class User
    {
        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        private string _username;
        private string _password;

        public User(string username, string password)
        {
            _username = username;
            _password = password;
        }
    }
}
