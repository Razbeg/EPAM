using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using TaskWebdriver.Logger;

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

        public void ReadSmokeJSON()
        {
            try
            {
                var jsonDirectory = $"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent}\\Properties\\UserDataSmoke.json";

                ReadJSONFile(jsonDirectory);
            }
            catch (Exception ex)
            {
                TestLogger.Instance.Error(ex);
            }
        }

        public void ReadJSON()
        {
            try
            {
                var jsonDirectory = $"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent}\\Properties\\UserData.json";

                ReadJSONFile(jsonDirectory);
            }
            catch (Exception ex)
            {
                TestLogger.Instance.Error(ex);
            }
        }

        private void ReadJSONFile(string jsonDirectory)
        {
            var jsonFile = File.ReadAllText(jsonDirectory);

            _userData = JsonSerializer.Deserialize<User>(jsonFile);
        }
    }
}
