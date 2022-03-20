﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenQA.Selenium;

namespace TaskWebdriver.Utilities
{
    public class TestUtilities
    {
        public static string Text { get; set; }

        public static string RandomText()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, new Random().Next(0, 25)).Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        public static void TakeScreenShot(IWebDriver driver)
        {
            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
            if (Directory.Exists("TaskWebdriver\\TaskWebdriver\\bin\\Debug\\netcoreapp3.1\\Screenshots"))
            {
                Directory.CreateDirectory("TaskWebdriver\\TaskWebdriver\\bin\\Debug\\netcoreapp3.1\\Screenshots");
            }
            screenshot.SaveAsFile($"Screenshots/screenshot_{DateTime.Now.ToString("dd-MM-yyyy_HH-mm")}.png", ScreenshotImageFormat.Png);
        }
    }
}
