﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TaskWebdriver.Utilities;

namespace TaskWebdriver.Pages
{
    public class GmailSendMailPage
    {
        private readonly string _composeMail = "//div[@class='T-I T-I-KE L3']";
        private readonly string _toEmailName = "to";
        private readonly string _subjectBoxName = "subjectbox";
        private readonly string _textBox = "//div[@role='textbox']";
        private readonly string _send = "//div[@role='button'][@class='T-I J-J5-Ji aoO v7 T-I-atl L3']";

        private IWebDriver _driver;

        public GmailSendMailPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SendMailTo(string email)
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
        }
    }
}