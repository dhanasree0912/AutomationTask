using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ReportGenerator;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIAutomation.Utilities
{
    public class UIActions
    {
         /// <summary>
         /// Clicks an element 
         /// </summary>
         /// <param name="driver">web driver</param>
         /// <param name="element">Xpath of an Element</param>
        public static void ClickByXpath(IWebDriver driver ,string element)
        {
            try
            {
                driver.FindElement(By.XPath(element)).Click();
                Reporter.LogToReport(Status.Info, "Element is clicked");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Reporter.LogToReport(Status.Fail, "Element is not clicked" + ex.Message);
            }
        }

        /// <summary>
        /// Hovers over the element
        /// </summary>
        /// <param name="driver">web driver</param>
        /// <param name="element">Xpath of an Element</param>
        public static void HoverElement(IWebDriver driver, string element)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000));
                Actions action = new Actions(driver);
                action.MoveToElement(driver.FindElement(By.XPath(element))).Perform();
                Reporter.LogToReport(Status.Info, "Element is Hovered");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Reporter.LogToReport(Status.Fail, "Element is not Hovered" + ex.Message);
            }

        }

        /// <summary>
        /// Enters the text into text box
        /// </summary>
        /// <param name="driver">web driver</param>
        /// <param name="element">Xpath of an Element</param>
        /// <param name="text">Text that need to be typed on web page</param>
        public static void EnterText(IWebDriver driver, string element, string text)
        {
            try
            {
                driver.FindElement(By.XPath(element)).SendKeys(text);
                Reporter.LogToReport(Status.Info, "Text is entered" );
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Reporter.LogToReport(Status.Fail, "Text is not entered" + ex.Message);
            }
        }

        /// <summary>
        /// Selects value from Dropdown
        /// </summary>
        /// <param name="driver">web driver</param>
        /// <param name="element">Xpath of an Element</param>
        /// <param name="value">Value that need to be selected</param>
        public static void EnterDropDwnValue(IWebDriver driver, string element, string value)
        {
            try
            {
                SelectElement selectElement = new SelectElement(driver.FindElement(By.XPath(element)));
                selectElement.SelectByText(value);
                Reporter.LogToReport(Status.Info, "Value is selected from dropdown");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Reporter.LogToReport(Status.Fail, "Value is not selected from dropdown" + ex.Message);
            }
        }
        /// <summary>
        /// Selects the check box
        /// </summary>
        /// <param name="driver">web driver</param>
        /// <param name="element">Xpath of an Element</param>
        public static void SelectCheckBox(IWebDriver driver, string element)
        {
            try
            {
                Actions action = new Actions(driver);
                action.MoveToElement(driver.FindElement(By.XPath(element))).Click().Perform();
                Reporter.LogToReport(Status.Info, "Checkbox is selected");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Reporter.LogToReport(Status.Fail, "Checkbox is not selected" + ex.Message);
            }

        }

        /// <summary>
        /// Generates a random string
        /// </summary>
        /// <param name="length">length of string</param>
        /// <returns>returns a random string</returns>
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Generates a random number
        /// </summary>
        /// <returns>returns a random number</returns>
        public static string RandomNumber()
        {
            const string chars = "0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 11)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Clicks the multiple links 
        /// </summary>
        /// <param name="driver">web driver</param>
        /// <param name="numbers">Count of Links</param>
        /// <returns>returns the list containing links</returns>
        public static List<string> ClickMultipleLinks(IWebDriver driver, int numbers)
        {
            List<string> links = new List<string>();
            for (int i = 1; i <= numbers; i++)
            {
                string element = "//*[@id='country-list-id']/ul/li[" + i + "]/a";
                ClickByXpath(driver, element);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            }

            IList<string> allWindowHandles = driver.WindowHandles;

            if (allWindowHandles.Count > 1)
            {
               
                for (int i = 0; i <= numbers; i++)
                {
                    driver.SwitchTo().Window(driver.WindowHandles[i]);
                    string link = driver.Url.ToString();
                    links.Add(link);
                }
                //return links;
            }
            return links;
        }
    }
}
