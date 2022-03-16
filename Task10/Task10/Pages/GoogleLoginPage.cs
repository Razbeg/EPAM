using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Task10.Pages
{
    public class GoogleLoginPage
    {
        private const string BASE_URL = "https://gmail.com/";
        /*
        [FindsBy(How = How.XPath, Using = "//input[@id='identifierId']")]
        private IWebElement _inputLogin;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement _inputPassword;

        [FindsBy(How = How.XPath, Using = "//div[@id='identifierNext']")]
        private IWebElement _identifierNext;

        [FindsBy(How = How.XPath, Using = "//div[@id='passwordNext']")]
        private IWebElement _passwordNext;
        */
        private IWebDriver _driver;

        public GoogleLoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void OpenPage()
        {
            _driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Login Page opened");
        }

        public void InputLogin(Model.User user)
        {
            IWebElement _inputLogin = _driver.FindElement(By.XPath("//input[@id='identifierId']"));
            _inputLogin.SendKeys(user.Username);

            IWebElement _identifierNext = _driver.FindElement(By.XPath("//div[@id='identifierNext']"));
            _identifierNext.Click();
        }

        public void InputPassword(Model.User user)
        {
            IWebElement _inputPassword = _driver.FindElement(By.XPath("//input[@name='password']"));
            _inputPassword.SendKeys(user.Password);

            IWebElement _passwordNext = _driver.FindElement(By.XPath("//div[@id='passwordNext']"));
            _passwordNext.Click();
        }
    }
}
