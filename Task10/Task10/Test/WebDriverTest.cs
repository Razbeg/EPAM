using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Task10.Properties;

namespace Task10
{
    public class WebDriverTest
    {
        private Steps.Steps _steps = new Steps.Steps();
        private IWebDriver _driver;

        [SetUp]
        public void Init()
        {
            _steps.InitBrowser();

            //_driver = new ChromeDriver();
            //_driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            _steps.CloseBrowser(); 
            //_driver.Quit();
        }

        [Test]
        public void LoginWithCorrectLoginPasswordTest()
        {
            _steps.LoginGmail(new Model.User(Data.GmailUsername, Data.GmailPassword));
            /*
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            _driver.Navigate().GoToUrl("https://gmail.com/");

            var account = _driver.FindElement(By.XPath("//input[@id='identifierId']"));
            account.SendKeys("elizabeth.highground@gmail.com");

            _driver.FindElement(By.XPath("//div[@id='identifierNext']")).Click();
            
            var password = _driver.FindElement(By.XPath("//input[@name='password']"));
            password.SendKeys("tTXj5huGK5mLvFQJ");

            _driver.FindElement(By.XPath("//div[@id='passwordNext']")).Click();
            */
        }
        
        [Test]
        public void LoginWithIncorrectLoginTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            _driver.Navigate().GoToUrl("https://gmail.com/");

            var account = _driver.FindElement(By.XPath("//input[@id='identifierId']"));
            account.SendKeys("elizabeth.highground@gmail");

            _driver.FindElement(By.XPath("//div[@id='identifierNext']")).Click();

            var wrongInput = _driver.FindElement(By.XPath("//span[@class='jibhHc']"));

            Assert.IsNotNull(wrongInput);
        }
        
        [Test]
        public void LoginWithIncorrectPasswordTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            _driver.Navigate().GoToUrl("https://gmail.com/");

            var account = _driver.FindElement(By.XPath("//input[@id='identifierId']"));
            account.SendKeys("elizabeth.highground@gmail.com");

            _driver.FindElement(By.XPath("//div[@id='identifierNext']")).Click();

            var password = _driver.FindElement(By.XPath("//input[@name='password']"));
            password.SendKeys("tT5mLvFQJ");

            _driver.FindElement(By.XPath("//div[@id='passwordNext']")).Click();

            var wrongInput = _driver.FindElement(By.XPath("//div[@class='OyEIQ uSvLId']"));

            Assert.IsNotNull(wrongInput);
        }

        [Test]
        public void LoginWithEmptyLoginTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            _driver.Navigate().GoToUrl("https://gmail.com/");

            var account = _driver.FindElement(By.XPath("//input[@id='identifierId']"));
            account.SendKeys("");

            _driver.FindElement(By.XPath("//div[@id='identifierNext']")).Click();

            var wrongInput = _driver.FindElement(By.XPath("//span[@class='jibhHc']"));

            Assert.IsNotNull(wrongInput);
        }

        [Test]
        public void LoginWithEmptyPasswordTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            _driver.Navigate().GoToUrl("https://gmail.com/");

            var account = _driver.FindElement(By.XPath("//input[@id='identifierId']"));
            account.SendKeys("elizabeth.highground@gmail.com");

            _driver.FindElement(By.XPath("//div[@id='identifierNext']")).Click();

            var password = _driver.FindElement(By.XPath("//input[@name='password']"));
            password.SendKeys("");

            var wrongInput = _driver.FindElement(By.XPath("//div[@class='OyEIQ uSvLId']"));

            Assert.IsNotNull(wrongInput);
        }
        
        // Need help, doesn't log in to outlook
        [Test]
        public void SendMailTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomText = new string(Enumerable.Repeat(chars, new Random().Next(0, 25)).Select(s => s[new Random().Next(s.Length)]).ToArray());

            #region First email login then sending mail
            _driver.Navigate().GoToUrl("https://gmail.com/");

            var account = _driver.FindElement(By.XPath("//input[@id='identifierId']"));
            account.SendKeys("elizabeth.highground@gmail.com");

            _driver.FindElement(By.XPath("//div[@id='identifierNext']")).Click();

            var password = _driver.FindElement(By.XPath("//input[@name='password']"));
            password.SendKeys("tTXj5huGK5mLvFQJ");

            _driver.FindElement(By.XPath("//div[@id='passwordNext']")).Click();

            _driver.FindElement(By.XPath("//div[@class='T-I T-I-KE L3']")).Click();

            var textAreaTo = _driver.FindElement(By.XPath("//textarea[@name='to']"));
            textAreaTo.SendKeys("norman.highground@outlook.com");

            var inputSubject = _driver.FindElement(By.XPath("//input[@name='subjectbox']"));
            inputSubject.SendKeys("Test Mail");

            var textBox = _driver.FindElement(By.XPath("//div[@role='textbox']"));
            textBox.SendKeys(randomText);

            _driver.FindElement(By.XPath("//div[@role='button'][@class='T-I J-J5-Ji aoO v7 T-I-atl L3']")).Click();
            #endregion

            _driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            
            _driver.SwitchTo().Alert().Accept();

            #region Second email login confirming mail
            _driver.Navigate().GoToUrl("https://outlook.live.com/");

            _driver.FindElement(By.XPath("//nav[@aria-label='Quick links']//a[@class='internal sign-in-link']")).Click();

            var loginSecond = _driver.FindElement(By.XPath("//input[@name='loginfmt']"));
            loginSecond.SendKeys("norman.highground@outlook.com");

            _driver.FindElement(By.XPath("//input[@type='submit'][@value='Next']")).Click();

            var passwordSecond = _driver.FindElement(By.XPath("//input[@name='passwd']"));
            loginSecond.SendKeys("gT8MJ55xN3N9ppK3");

            _driver.FindElement(By.XPath("//input[@type='submit'][@value='Sign in']")).Click();

            _driver.FindElement(By.XPath("//button[@class='ms-Button GJoz3Svb7GjPbATIMTlpL _2W_XxC_p1PufyiP8wuAvwF lZNvAQjEfdlNWkGGuJb7d ms-Button--commandBar Gf6FgM99ZJ9S8H48pFMdB root-168']")).Click();
            #endregion
        }

        [Test]
        public void ChangeNicknameTest()
        {
            string changeToName = "Lisa";

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            _driver.Navigate().GoToUrl("https://gmail.com/");

            var account = _driver.FindElement(By.XPath("//input[@id='identifierId']"));
            account.SendKeys("elizabeth.highground@gmail.com");

            _driver.FindElement(By.XPath("//div[@id='identifierNext']")).Click();

            var password = _driver.FindElement(By.XPath("//input[@name='password']"));
            password.SendKeys("tTXj5huGK5mLvFQJ");

            _driver.FindElement(By.XPath("//div[@id='passwordNext']")).Click();

            _driver.FindElement(By.XPath("//a[@class='gb_A gb_Ka gb_f']")).Click();

            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath("//div[@class='gb_Td gb_Va gb_Id gb_Wd']//div[3]//iframe[1]")));

            _driver.FindElement(By.XPath("//a[@class='ksO4Qc ZWVAt R37Fhd']")).Click();

            _driver.SwitchTo().Window(_driver.WindowHandles[1]);

            _driver.FindElement(By.XPath("//div[3]//c-wiz[1]//nav[1]//ul[1]//li[2]//a[1]")).Click();

            _driver.FindElement(By.XPath("//a[@href='name']")).Click();

            var name = _driver.FindElements(By.XPath("//input[@type='text']"));
            name[1].Clear();
            name[1].SendKeys(changeToName);

            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            _driver.FindElement(By.XPath("//body/c-wiz/div/div/div[@jscontroller='ZKtqpf']/div/div[@role='navigation']/div[1]")).Click();

            _driver.FindElement(By.XPath("//a[@href='name']")).Click();
            name = _driver.FindElements(By.XPath("//input[@type='text']"));

            Assert.AreEqual(name[1].GetAttribute("value"), changeToName);
        }
    }
}
