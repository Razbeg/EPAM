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

        private readonly By _searchLocator = By.XPath("//a[@id='orbit-search-button']");
        private readonly By _navigationLocator = By.XPath("//a[@class='sp-c-sport-navigation__link qa-primary-item sp-nav-click-stat']");
        private readonly By _signIn = By.XPath("//div[@id='idcta-statusbar']");
        private readonly By _socialLinkTwitter = By.XPath("//a[@class='sp-c-fuh-social sp-c-fuh-social--twitter']");
        private readonly By _socialLinkYoutube = By.XPath("//a[@class='sp-c-fuh-social sp-c-fuh-social--youtube']");

        [SetUp]
        public void StartBrowser()
        {
            _driver = new ChromeDriver();

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.bbc.com/sport");
        }

        [Test]
        public void SearchTest()
        {
            _driver.FindElement(_searchLocator).Click();
        }

        [Test]
        public void NavigationTabTest()
        {
            var elements = _driver.FindElements(_navigationLocator);

            elements[new Random().Next(0, elements.Count)].Click();
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

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}
