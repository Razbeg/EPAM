using NUnit.Framework;
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
            _driver = DriverInstance.GetDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            DriverInstance.CloseBrowser();
        }

        [TestCase(UserData.GmailValidUsername, UserData.GmailValidPassword)]
        
        public void LoginGmailValid(string username, string password)
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver);
            loginPage.OpenPage();

            loginPage.Login(username, password);

            Assert.IsTrue(TestUtilities.CheckValid);
        }

        [TestCase(UserData.GmailValidUsername, UserData.GmailInvalidPassword)]
        [TestCase(UserData.GmailInvalidUsername, UserData.GmailInvalidPassword)]
        [TestCase(UserData.GmailEmptyUsername, UserData.GmailEmptyPassword)]
        public void LoginGmailInvalid(string username, string password)
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver);
            loginPage.OpenPage();

            loginPage.Login(username, password);

            Assert.IsTrue(!TestUtilities.CheckValid);
        }

        [TestCase(UserData.GmailValidUsername, UserData.GmailValidPassword)]
        public void ChangeNickname(string username, string password)
        {
            GmailChangeNicknamePage changeNicknamePage = new GmailChangeNicknamePage(_driver);
            changeNicknamePage.Login(username, password);
            changeNicknamePage.ChangeNickname();

            Assert.IsTrue(TestUtilities.CheckValid);
        }

        [TestCase(UserData.GmailValidUsername, UserData.GmailValidPassword)]
        public void SendMail(string username, string password)
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver);
            loginPage.OpenPage();
            loginPage.Login(username, password);

            GmailSendMailPage sendMailPage = new GmailSendMailPage(_driver);
            sendMailPage.SendMailTo(UserData.MailRuUsername);

            MailRuPage mailRuLoginPage = new MailRuPage(_driver);
            mailRuLoginPage.OpenPage();
            mailRuLoginPage.Login(UserData.MailRuUsername, UserData.MailRuPassword);
            mailRuLoginPage.CheckMail();

            Assert.IsTrue(TestUtilities.CheckValid);
        }
    }
}
