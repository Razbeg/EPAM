using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TaskWebdriver.Utilities;

namespace TaskWebdriver.Pages
{
    public class MailRuPage
    {
        private const string BaseUrl = "https://mail.ru/";

        private readonly By _login = By.XPath("//div[@data-testid='logged-out-one-click']//button");
        private readonly By _loginIFrame = By.XPath("//iframe[@class='ag-popup__frame__layout__iframe']");
        private readonly By _usernameInput = By.Name("username");
        private readonly By _passwordInput = By.Name("password");
        private readonly By _submit = By.XPath("//button[@type='submit']");
        private readonly By _sentMail = By.XPath("//*[contains(@title, 'Elizabeth')]");

        private IWebDriver _driver;

        public MailRuPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void OpenPage()
        {
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.SwitchTo().NewWindow(WindowType.Tab);
            _driver.Navigate().GoToUrl(BaseUrl);
        }

        public void Login(string username, string password)
        {
            _driver.FindElement(_login).Click();
            _driver.SwitchTo().Frame(_driver.FindElement(_loginIFrame));

            var usernameElement = _driver.FindElement(_usernameInput);
            usernameElement.SendKeys(username);

            var submitElement = _driver.FindElement(_submit);
            submitElement.Click();

            var passwordElement = _driver.FindElement(_passwordInput);
            passwordElement.SendKeys(password);

            submitElement = _driver.FindElement(_submit);
            submitElement.Click();
        }

        public void CheckMail()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _driver.FindElement(_sentMail).Click();

            Thread.Sleep(5000);
        }
    }
}
