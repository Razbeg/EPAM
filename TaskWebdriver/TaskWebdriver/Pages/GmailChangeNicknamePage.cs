using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskWebdriver.Pages
{
    public class GmailChangeNicknamePage
    {
        public string ChangeToName => ChangeTo;
        private const string ChangeTo = "Lisa";

        private readonly string _accountsManager = "//a[@href='https://accounts.google.com/SignOutOptions?hl=ru&continue=https://mail.google.com&service=mail']";
        private readonly string _accountsIframe = "(//iframe[contains(@role,'presentation')])[2]";
        private readonly string _manageAccountLink = "//a[@href='https://myaccount.google.com/?hl=ru&authuser=0&utm_source=OGB&utm_medium=act']";
        private readonly string _personalInfo = "(//a[@href='personal-info'])[2]";
        private readonly string _personalName = "//a[@href='name']";
        private readonly string _inputText = "//input[@type='text']";
        private readonly string _submitNutton = "//button[@type='submit']";
        private readonly string _back = "//div[@role='navigation']//div[1]//span[1]//span[1]//span[1]";

        private IWebDriver _driver;

        public GmailChangeNicknamePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Login(string username, string password)
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver);
            loginPage.OpenPage();
            loginPage.Login(username, password);
        }

        public string ChangeNickname()
        {
            _driver.FindElement(By.XPath(_accountsManager)).Click();
            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath(_accountsIframe)));
            _driver.FindElement(By.XPath(_manageAccountLink)).Click();

            _driver.SwitchTo().Window(_driver.WindowHandles[1]);

            _driver.FindElement(By.XPath(_personalInfo)).Click();
            _driver.FindElement(By.XPath(_personalName)).Click();

            var name = _driver.FindElements(By.XPath(_inputText));
            name[1].Clear();
            name[1].SendKeys(ChangeTo);

            _driver.FindElement(By.XPath(_submitNutton)).Click();
            _driver.FindElement(By.XPath(_back)).Click();

            _driver.FindElement(By.XPath(_personalName)).Click();
            name = _driver.FindElements(By.XPath(_inputText));

            return name[1].GetAttribute("value");
        }

        public void ChangeNicknameBack()
        {
            var name = _driver.FindElements(By.XPath(_inputText));
            name[1].Clear();
            name[1].SendKeys("Elizabeth");

            _driver.FindElement(By.XPath(_submitNutton)).Click();
        }
    }
}
