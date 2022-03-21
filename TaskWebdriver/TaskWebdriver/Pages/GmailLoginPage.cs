using OpenQA.Selenium;
using TaskWebdriver.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using TaskWebdriver.Utilities;

namespace TaskWebdriver.Pages
{
    public class GmailLoginPage
    {
        private const string BaseUrl = "https://gmail.com/";

        private readonly string _inputLoginId = "identifierId";
        private readonly string _identifierNextId = "identifierNext";
        private readonly string _inputPasswordName = "password";
        private readonly string _passwordNextId = "passwordNext";

        private IWebDriver _driver;

        public GmailLoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void OpenPage()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Navigate().GoToUrl(BaseUrl);
        }

        public void Login(string username, string password)
        {
            var inputLogin = _driver.FindElement(By.Id(_inputLoginId));
            inputLogin.SendKeys(username);

            var identifierNext = _driver.FindElement(By.Id(_identifierNextId));
            identifierNext.Click();

            var inputPassword = _driver.FindElement(By.Name(_inputPasswordName));
            inputPassword.SendKeys(password);

            var passwordNext = _driver.FindElement(By.Id(_passwordNextId));
            passwordNext.Click();
        }
    }
}
