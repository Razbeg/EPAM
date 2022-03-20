using NUnit.Framework;
using TaskWebdriver.Pages;
using TaskWebdriver.Driver;
using TaskWebdriver.Utilities;
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

        //[TestCase("elizabeth.highground@gmail.com", "tTXj5huGK5mLvFQJ")]
        [TestCase("elizabeth.highground@gmail", "")]
        //[TestCase("elizabeth.highground@gmail.com", "tTXj5huG")]
        //[TestCase("", "")]
        public void LoginGmail(string username, string password)
        {
            try
            {
                GmailLoginPage loginPage = new GmailLoginPage(_driver);
                loginPage.OpenPage();
                loginPage.Login(username, password);
            }
            catch (Exception)
            {
                TestUtilities.TakeScreenShot(_driver);
            }
        }

        [TestCase("elizabethnorman965", "GeMyYoq3WMVL")]
        public void ChangeNickname(string username, string password)
        {
            GmailChangeNicknamePage changeNicknamePage = new GmailChangeNicknamePage(_driver);
            changeNicknamePage.Login(username, password);

            var changedNickname = changeNicknamePage.ChangeNickname();

            if (changedNickname == changeNicknamePage.ChangeToName)
            {
                Console.WriteLine($"Changing current nickname '{changedNickname}' to 'Elizabeth'");
                changeNicknamePage.ChangeNicknameBack();
                Console.WriteLine($"'{changedNickname}' not current nickname");
            }
        }

        [TestCase("elizabethnorman965", "GeMyYoq3WMVL")]
        public void SendMail(string username, string password)
        {
            GmailLoginPage loginPage = new GmailLoginPage(_driver);
            loginPage.OpenPage();
            loginPage.Login(username, password);

            GmailSendMailPage sendMailPage = new GmailSendMailPage(_driver);
            sendMailPage.SendMailTo("norman.highground@bk.ru");

            MailRuPage mailRuLoginPage = new MailRuPage(_driver);
            mailRuLoginPage.OpenPage();
            mailRuLoginPage.Login("norman.highground@bk.ru", "gT8MJ55xN3N9ppK3");
            mailRuLoginPage.CheckMail();
        }
    }
}
