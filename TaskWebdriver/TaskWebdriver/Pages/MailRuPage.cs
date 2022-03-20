using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskWebdriver.Utilities;

namespace TaskWebdriver.Pages
{
    public class MailRuPage
    {
        private const string BaseUrl = "https://mail.ru/";

        private readonly string _login = "//div[@data-testid='logged-out-one-click']//button";
        private readonly string _loginIFrame = "//iframe[@class='ag-popup__frame__layout__iframe']";
        private readonly string _usernameInputName = "username";
        private readonly string _passwordInputName = "password";
        private readonly string _submit = "//button[@type='submit']";

        private readonly string _sentMail = "//span[@title='Elizabeth Norman <elizabethnorman965@gmail.com>']";

        private IWebDriver _driver;

        private string _username;

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
            _username = username;

            _driver.FindElement(By.XPath(_login)).Click();
            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath(_loginIFrame)));

            var usernameElement = _driver.FindElement(By.Name(_usernameInputName));
            usernameElement.SendKeys(username);

            var submitElement = _driver.FindElement(By.XPath(_submit));
            submitElement.Click();

            var passwordElement = _driver.FindElement(By.Name(_passwordInputName));
            passwordElement.SendKeys(password);

            submitElement = _driver.FindElement(By.XPath(_submit));
            submitElement.Click();
        }

        public void CheckMail()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _driver.FindElement(By.XPath(_sentMail)).Click();

            var sentMailText = _driver.FindElement(By.XPath($"//div[contains(text(),'{TestUtilities.Text}')]"));

            if (sentMailText.Text != null)
            {
                Console.WriteLine(_username);
            }

            TestUtilities.TakeScreenShot(_driver);
        }
    }
}
