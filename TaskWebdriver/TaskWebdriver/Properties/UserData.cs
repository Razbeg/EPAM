using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace TaskWebdriver.Properties
{
    public class UserData
    {
        private User _userData;

        public string GmailInvalidUsername = "asdf";
        public string GmailInvalidPassword = "yYoq3";

        public string GmailEmptyUsername = "";
        public string GmailEmptyPassword = "";

        public string GmailValidUsername => _userData.GmailUsername;
        public string GmailValidPassword => _userData.GmailPassword;

        public string MailRuUsername => _userData.MailRuUsername;
        public string MailRuPassword => _userData.MailRuPassword;

        public UserData()
        {

        }

        public void ReadJSON(bool smokeTest)
        {
            var jsonDirectory = smokeTest ? 
                $"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent}\\Properties\\UserDataSmoke.json" :
                $"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent}\\Properties\\UserData.json";

            var jsonFile = File.ReadAllText(jsonDirectory);

            _userData = JsonSerializer.Deserialize<User>(jsonFile);
        }
    }
}
