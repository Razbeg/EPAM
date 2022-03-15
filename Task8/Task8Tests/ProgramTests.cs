using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task8;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task8.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void OnlyAlpabetLettersFirst_LatinAlphabetLettersTest()
        {
            string currentWord = "asfddsss";
            string expected = $"{currentWord} has 3 unequal consecutive characters";

            string actual = Program.LatinAlphabetLetters(currentWord);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OnlyAlpabetLettersSecond_LatinAlphabetLettersTest()
        {
            string currentWord = "jandossa";
            string expected = $"{currentWord} has 5 unequal consecutive characters";

            string actual = Program.LatinAlphabetLetters(currentWord);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OnlyAlpabetLettersThird_LatinAlphabetLettersTest()
        {
            string currentWord = "aaaaaaaaaa";
            string expected = $"{currentWord} has 0 unequal consecutive characters";

            string actual = Program.LatinAlphabetLetters(currentWord);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AnyCharacters_LatinAlphabetLettersTest()
        {
            string currentWord = "15#$as45ss";
            string expected = $"{currentWord} has non-Latin alphabet character or characters!";

            string actual = Program.LatinAlphabetLetters(currentWord);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OnlyDigitsFirst_DigitsTest()
        {
            string currentWord = "11584555";
            string expected = $"{currentWord} has 4 unequal consecutive characters";

            string actual = Program.Digits(currentWord);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OnlyDigitsSecond_DigitsTest()
        {
            string currentWord = "84576594";
            string expected = $"{currentWord} has 7 unequal consecutive characters";

            string actual = Program.Digits(currentWord);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OnlyDigitsThird_DigitsTest()
        {
            string currentWord = "88888888";
            string expected = $"{currentWord} has 0 unequal consecutive characters";

            string actual = Program.Digits(currentWord);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AnyCharacters_DigitsTest()
        {
            string currentWord = "15#$as45ss";
            string expected = $"{currentWord} has non-digit character or characters!";

            string actual = Program.Digits(currentWord);

            Assert.AreEqual(expected, actual);
        }
    }
}