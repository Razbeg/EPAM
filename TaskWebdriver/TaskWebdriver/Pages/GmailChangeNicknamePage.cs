using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TaskWebdriver.Properties;
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
        private readonly By _inputText = By.XPath("//input[@value='Elizabeth']");
        private readonly By _inputTextFrom = By.XPath($"//input[@value='{ChangeTo}']");
        private readonly By _submitNutton = By.XPath("//button[@type='submit']");

        private IWebDriver _driver;
        private UserData _userdata;

        public IWebElement actual => _driver.FindElement(By.XPath($"//*[contains(text(), 'Elizabeth')]"));

        public GmailChangeNicknamePage(IWebDriver driver, UserData userData)
        {
            _driver = driver;
            _userdata = userData;
            _driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
        }

        public void Login(string username, string password)
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver, _userdata);
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

            var name = _driver.FindElement(_inputText);
            name.Clear();
            name.SendKeys(ChangeTo);

            _driver.FindElement(_submitNutton).Click();
            _driver.Navigate().Back();
            _driver.Navigate().Refresh();

            _driver.FindElement(_personalName).Click();

            ChangeNicknameBack();
        }

        public void ChangeNicknameBack()
        {
            var name = _driver.FindElement(_inputTextFrom);
            name.Clear();
            name.SendKeys("Elizabeth");

            _driver.FindElement(_submitNutton).Click();
            _driver.Navigate().Back();
            _driver.Navigate().Refresh();
        }
        
    }
}
