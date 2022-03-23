using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task9
{
    public class Task9LocatorsTest
    {
        private IWebDriver _driver;

        private readonly By _searchLocator = By.Id("orbit-search-button");
        private readonly By _homeTab = By.XPath("//div[@aria-label='Primary']//*[@data-stat-title='Home']");
        private readonly By _signIn = By.Id("idcta-statusbar");
        private readonly By _socialLinkTwitter = By.XPath("//*[contains(@class, 'twitter')]");
        private readonly By _socialLinkYoutube = By.XPath("//*[contains(@class, 'youtube')]");

        [SetUp]
        public void StartBrowser()
        {
            _driver = new ChromeDriver();

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.bbc.com/sport");
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }

        [Test]
        public void SearchTest()
        {
            _driver.FindElement(_searchLocator).Click();
        }

        [Test]
        public void HomeTabTest()
        {
            _driver.FindElement(_homeTab).Click();
        }

        [Test]
        public void SignInTest()
        {
            _driver.FindElement(_signIn).Click();
        }

        [Test]
        public void SocialLinkTwiiterTest()
        {
            Assert.IsNotNull(_driver.FindElement(_socialLinkTwitter));
        }

        [Test]
        public void SocialLinkYoutubeTest()
        {
            Assert.IsNotNull(_driver.FindElement(_socialLinkYoutube));
        }
    }
}
