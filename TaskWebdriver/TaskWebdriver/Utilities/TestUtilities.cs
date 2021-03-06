using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using TaskWebdriver.Logger;

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
            try
            {
                Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
                screenshot.SaveAsFile($"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent}\\Screenshots\\{TestContext.CurrentContext.Test.Name}_{DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss")}.png", ScreenshotImageFormat.Png);
            }
            catch (Exception ex)
            {
                TestLogger.Instance.Error(ex);
            }
        }

        public static void CleanFolder()
        {
            try
            {
                var screenshotsList = Directory.GetFiles($"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent}\\Screenshots");

                foreach (var screenshot in screenshotsList)
                {
                    File.Delete(screenshot);
                }
            }
            catch (Exception ex)
            {
                TestLogger.Instance.Error(ex);
            }
        }
    }
}
