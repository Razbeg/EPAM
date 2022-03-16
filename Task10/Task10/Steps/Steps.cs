using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task10.Steps
{
    public class Steps
    {
        private IWebDriver _driver;

        public void InitBrowser()
        {
            _driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void LoginGmail(Model.User user)
        {
            Pages.GoogleLoginPage loginPage = new Pages.GoogleLoginPage(_driver);
            loginPage.OpenPage();
            loginPage.InputLogin(user);
            loginPage.InputPassword(user);
        }
    }
}
