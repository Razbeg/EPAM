using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskWebdriver.Driver;
using TaskWebdriver.Logger;
using TaskWebdriver.Pages;
using TaskWebdriver.Properties;
using TaskWebdriver.Utilities;

namespace TaskWebdriver.Test
{
    [TestFixture]
    public class SmokeTest
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

            _userData.ReadSmokeJSON();
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

        [Test, Category("SmokeTests")]
        public void SendMailSmokeTest()
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

        [Test, Category("SmokeTests")]
        public void LoginGmailValidSmokeTest()
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver, _userData);
            loginPage.OpenPage();
            loginPage.Login(_userData.GmailValidUsername, _userData.GmailValidPassword);

            Assert.IsTrue(loginPage.checkLogin.Displayed);
        }
    }
}
