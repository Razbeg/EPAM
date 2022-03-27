using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TaskWebdriver.Pages;
using TaskWebdriver.Driver;
using TaskWebdriver.Utilities;
using TaskWebdriver.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OpenQA.Selenium;
using TaskWebdriver.Logger;

namespace TaskWebdriver.Test
{
    [TestFixture]
    public class WebDriverTest
    {
        private IWebDriver _driver;

        private UserData _userData;

        [OneTimeSetUp]
        public void Awake()
        {
            TestUtilities.CleanFolder();

            _userData = new UserData();
        }

        [SetUp]
        public void Init()
        {
            _driver = DriverInstance.GetDriver();

            _userData.ReadJSON();
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                TestUtilities.TakeScreenShot(_driver);
            }

            DriverInstance.CloseBrowser();
            TestLogger.LoggerShutDown();
        }

        [Test, Category("AllTests")]
        public void LoginGmailValidTest()
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver, _userData);
            loginPage.OpenPage();
            loginPage.Login(_userData.GmailValidUsername, _userData.GmailValidPassword);

            Assert.IsTrue(loginPage.checkLogin.Displayed);
        }

        [Test, Category("AllTests")]
        public void LoginGmailInvalidTest()
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver, _userData);
            loginPage.OpenPage();
            loginPage.Login(_userData.GmailInvalidUsername, _userData.GmailInvalidPassword);

            Assert.IsTrue(loginPage.checkLoginInvalid.Displayed);
        }

        [Test, Category("AllTests")]
        public void LoginGmailEmptyTest()
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver, _userData);
            loginPage.OpenPage();
            loginPage.Login(_userData.GmailEmptyUsername, _userData.GmailEmptyPassword);

            Assert.IsTrue(loginPage.checkLoginEmpty.Displayed);
        }
        
        [Test, Category("AllTests")]
        public void ChangeNicknameTest()
        {
            GmailChangeNicknamePage changeNicknamePage = new GmailChangeNicknamePage(_driver, _userData);
            changeNicknamePage.Login(_userData.GmailValidUsername, _userData.GmailValidPassword);
            changeNicknamePage.ChangeNickname();

            Assert.IsTrue(changeNicknamePage.actual.Displayed);
        }

        [Test, Category("AllTests")]
        public void SendMailTest()
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver, _userData);
            loginPage.OpenPage();
            loginPage.Login(_userData.GmailValidUsername, _userData.GmailValidPassword);

            GmailSendMailPage sendMailPage = new GmailSendMailPage(_driver);
            sendMailPage.SendMailTo(_userData.MailRuUsername);

            MailRuPage mailRuLoginPage = new MailRuPage(_driver);
            mailRuLoginPage.OpenPage();
            mailRuLoginPage.Login(_userData.MailRuUsername, _userData.MailRuPassword);
            mailRuLoginPage.CheckMail();

            Assert.IsTrue(mailRuLoginPage.sentMailText.Displayed);
        }
    }
}
