using OpenQA.Selenium;
using TaskWebdriver.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using TaskWebdriver.Properties;
using System.Threading;

namespace TaskWebdriver.Pages
{
    public class GmailLoginPage
    {
        private const string BaseUrl = "https://gmail.com/";

        private readonly By _inputLogin = By.Id("identifierId");
        private readonly By _identifierNext = By.Id("identifierNext");
        private readonly By _inputPassword = By.Name("password");
        private readonly By _passwordNext = By.Id("passwordNext");

        private IWebDriver _driver;
        private UserData _userData;

        public GmailLoginPage(IWebDriver driver, UserData userdata)
        {
            _driver = driver;
            _userData = userdata;
        }

        public IWebElement checkLogin => _driver.FindElement(By.XPath($"//*[contains(@aria-label, '{_userData.GmailValidUsername}')]"));
        public IWebElement checkLoginInvalid => _driver.FindElement(By.XPath("//*[@badinput='false']"));
        public IWebElement checkLoginEmpty => _driver.FindElement(By.XPath("//*[@aria-invalid='true']"));

        public void OpenPage()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Navigate().GoToUrl(BaseUrl);
        }

        public void Login(string username, string password)
        {
            var inputLogin = _driver.FindElement(_inputLogin);
            inputLogin.SendKeys(username);

            var identifierNext = _driver.FindElement(_identifierNext);
            identifierNext.Click();

            if (username == _userData.GmailValidUsername)
            {
                var inputPassword = _driver.FindElement(_inputPassword);
                inputPassword.SendKeys(password);

                var passwordNext = _driver.FindElement(_passwordNext);
                passwordNext.Click();

                Thread.Sleep(5000);
            }
        }
    }
}
