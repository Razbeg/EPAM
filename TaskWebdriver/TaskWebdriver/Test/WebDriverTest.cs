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

        [OneTimeSetUp]
        public void Awake()
        {
            TestUtilities.CleanFolder();
        }

        [SetUp]
        public void Init()
        {
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

            Assert.IsTrue(loginPage.checkLogin.Displayed);
        }

        [Test]
        public void LoginGmailInvalidTest()
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver);
            loginPage.OpenPage();
            loginPage.Login(UserData.GmailInvalidUsername, UserData.GmailInvalidPassword);

            Assert.IsTrue(loginPage.checkLoginInvalid.Displayed);
        }

        [Test]
        public void LoginGmailEmptyTest()
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver);
            loginPage.OpenPage();
            loginPage.Login(UserData.GmailEmptyUsername, UserData.GmailEmptyPassword);

            Assert.IsTrue(loginPage.checkLoginEmpty.Displayed);
        }
        
        [Test]
        public void ChangeNicknameTest()
        {
            GmailChangeNicknamePage changeNicknamePage = new GmailChangeNicknamePage(_driver);
            changeNicknamePage.Login(UserData.GmailValidUsername, UserData.GmailValidPassword);
            changeNicknamePage.ChangeNickname();

            Assert.IsNotNull(changeNicknamePage.actual);
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

            Assert.IsTrue(mailRuLoginPage.sentMailText.Displayed);
        }
    }
}
