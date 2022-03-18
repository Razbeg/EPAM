using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task8;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task8.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("asfddsss", "asfddsss has 3 unequal consecutive characters")]
        [DataRow("jandossa", "jandossa has 5 unequal consecutive characters")]
        [DataRow("aaaaaaaaaa", "aaaaaaaaaa has 0 unequal consecutive characters")]
        [DataRow("15#$as45ss", "15#$as45ss has non-Latin alphabet character or characters!")]
        public void LatinAlphabetLettersTest(string word, string expected)
        {
            string actual = Program.LatinAlphabetLetters(word);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("11584555", "11584555 has 4 unequal consecutive characters")]
        [DataRow("84576594", "84576594 has 7 unequal consecutive characters")]
        [DataRow("88888888", "88888888 has 0 unequal consecutive characters")]
        [DataRow("15#$as45ss", "15#$as45ss has non-digit character or characters!")]
        public void DigitsTest(string digits, string expected)
        {
            string actual = Program.Digits(digits);

            Assert.AreEqual(expected, actual);
        }
    }
}