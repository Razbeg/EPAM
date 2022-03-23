using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TaskWebdriver.Utilities;

namespace TaskWebdriver.Pages
{
    public class GmailChangeNicknamePage
    {
        public string ChangeToName => ChangeTo;
        private const string ChangeTo = "Lisa";

        private readonly By _accountsManager = By.XPath("//*[contains(@href, 'SignOutOptions')]");
        private readonly By _accountsIframe = By.XPath("//iframe[contains(@src, 'account')]");
        private readonly By _manageAccountLink = By.XPath("//*[contains(@href, 'authuser')]");
        private readonly By _personalInfo = By.XPath("//a[@href='personal-info']//img");
        private readonly By _personalName = By.XPath("//a[@href='name']");
        private readonly By _inputText = By.XPath("//input[@type='text']");
        private readonly By _submitNutton = By.XPath("//button[@type='submit']");

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

        public void ChangeNickname()
        {
            _driver.FindElement(_accountsManager).Click();
            _driver.SwitchTo().Frame(_driver.FindElement(_accountsIframe));
            _driver.FindElement(_manageAccountLink).Click();

            _driver.SwitchTo().Window(_driver.WindowHandles[1]);

            _driver.FindElement(_personalInfo).Click();
            _driver.FindElement(_personalName).Click();

            var name = _driver.FindElements(_inputText);
            name[1].Clear();
            name[1].SendKeys(ChangeTo);

            _driver.FindElement(_submitNutton).Click();
            _driver.Navigate().Back();
            _driver.Navigate().Refresh();
        }

        /*
        public void ChangeNicknameBack()
        {
            var name = _driver.FindElements(By.XPath(_inputText));
            name[1].Clear();
            name[1].SendKeys("Elizabeth");

            _driver.FindElement(By.XPath(_submitNutton)).Click();
        }
        */
    }
}
