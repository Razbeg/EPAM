using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TaskWebdriver.Pages;
using TaskWebdriver.Driver;
using TaskWebdriver.Utilities;
using TaskWebdriver.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TaskWebdriver.Test
{
    public class WebDriverTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void Init()
        {
            TestUtilities.CleanFolder();
            _driver = DriverInstance.GetDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                TestUtilities.TakeScreenShot(_driver);
            }

            DriverInstance.CloseBrowser();
        }

        [Test]
        public void LoginGmailValidTest()
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver);
            loginPage.OpenPage();
            loginPage.Login(UserData.GmailValidUsername, UserData.GmailValidPassword);

            var checkLogin = _driver.FindElement(By.XPath($"//*[contains(@aria-label, '{UserData.GmailValidUsername}')]"));

            Assert.IsNotNull(checkLogin);
        }

        [Test]
        public void LoginGmailInvalidTest()
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver);
            loginPage.OpenPage();
            loginPage.Login(UserData.GmailInvalidUsername, UserData.GmailInvalidPassword);

            var checkLogin = _driver.FindElement(By.XPath("//*[@badinput='false']"));

            Assert.IsNotNull(checkLogin);
        }

        [Test]
        public void LoginGmailEmptyTest()
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver);
            loginPage.OpenPage();
            loginPage.Login(UserData.GmailEmptyUsername, UserData.GmailEmptyPassword);

            var checkLogin = _driver.FindElement(By.XPath("//*[@aria-invalid='true']"));

            Assert.IsNotNull(checkLogin);
        }

        [Test]
        public void ChangeNicknameTest()
        {
            GmailChangeNicknamePage changeNicknamePage = new GmailChangeNicknamePage(_driver);
            changeNicknamePage.Login(UserData.GmailValidUsername, UserData.GmailValidPassword);
            changeNicknamePage.ChangeNickname();

            var actual = _driver.FindElement(By.XPath($"//*[contains(text(), '{changeNicknamePage.ChangeToName}')]"));

            Assert.IsNotNull(actual);
        }

        [Test]
        public void SendMailTest()
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver);
            loginPage.OpenPage();
            loginPage.Login(UserData.GmailValidUsername, UserData.GmailValidPassword);

            GmailSendMailPage sendMailPage = new GmailSendMailPage(_driver);
            sendMailPage.SendMailTo(UserData.MailRuUsername);

            MailRuPage mailRuLoginPage = new MailRuPage(_driver);
            mailRuLoginPage.OpenPage();
            mailRuLoginPage.Login(UserData.MailRuUsername, UserData.MailRuPassword);
            mailRuLoginPage.CheckMail();

            var sentMailText = _driver.FindElement(By.XPath($"//div[contains(text(),'{TestUtilities.Text}')]"));

            Assert.IsNotNull(sentMailText);
        }
    }
}
