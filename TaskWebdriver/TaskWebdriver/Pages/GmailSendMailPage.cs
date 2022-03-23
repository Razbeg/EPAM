using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TaskWebdriver.Utilities;

namespace TaskWebdriver.Pages
{
    public class GmailSendMailPage
    {
        private readonly By _composeMail = By.XPath("//*[@role='navigation']//div[@role='button']");
        private readonly By _toEmailName = By.Name("to");
        private readonly By _subjectBoxName = By.Name("subjectbox");
        private readonly By _textBox = By.XPath("//div[@role='textbox']");
        private readonly By _send = By.XPath("//*[contains(@aria-label, 'Enter')]");

        private IWebDriver _driver;

        public GmailSendMailPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SendMailTo(string email)
        {
            TestUtilities.Text = TestUtilities.RandomText();

            _driver.FindElement(_composeMail).Click();

            var toEmail = _driver.FindElement(_toEmailName);
            toEmail.SendKeys(email);

            var inputSubject = _driver.FindElement(_subjectBoxName);
            inputSubject.SendKeys("Test mail");

            var textBox = _driver.FindElement(_textBox);
            textBox.SendKeys(TestUtilities.Text);

            _driver.FindElement(_send).Click();

            Thread.Sleep(5000);
        }
    }
}
