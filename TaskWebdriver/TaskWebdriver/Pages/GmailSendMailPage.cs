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
        private readonly string _composeMail = "(//*[@role='navigation']//*[@role='button'])[1]";
        private readonly string _toEmailName = "to";
        private readonly string _subjectBoxName = "subjectbox";
        private readonly string _textBox = "//div[@role='textbox']";
        private readonly string _send = "(//*[@role='group']//*[@role='button'])[1]";

        private IWebDriver _driver;

        public GmailSendMailPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SendMailTo(string email)
        {
            try
            {
                TestUtilities.Text = TestUtilities.RandomText();

                _driver.FindElement(By.XPath(_composeMail)).Click();

                var toEmail = _driver.FindElement(By.Name(_toEmailName));
                toEmail.SendKeys(email);

                var inputSubject = _driver.FindElement(By.Name(_subjectBoxName));
                inputSubject.SendKeys("Test mail");

                var textBox = _driver.FindElement(By.XPath(_textBox));
                textBox.SendKeys(TestUtilities.Text);

                _driver.FindElement(By.XPath(_send)).Click();

                Thread.Sleep(10000);

                TestUtilities.CheckValid = true;

            }
            catch (Exception ex)
            {
                TestUtilities.CheckValid = false;
                TestUtilities.TakeScreenShot(_driver);

                Console.WriteLine(ex.Message);
            }
        }
    }
}
