using System;
using AventStack.ExtentReports;
//using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ReportGenerator;

namespace UIAutomation.BaseClass
{
    public class BaseClass
    {
        static IWebDriver driver;
        private static WebDriverWait wait;

        static string test_url = "https://www.sogeti.com/";
        /// <summary>
        /// Creates a Chrome Driver Instance and Opens the Sogeti Web site
        /// </summary>
        /// <returns>returns the web driver</returns>
        public static IWebDriver BaseClassDriver()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(test_url);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            Utilities.UIActions.ClickByXpath(driver, WebElements.WebElements.AcceptCookies);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            Reporter.LogToReport(Status.Info, "Sogeti WebSite is opened");
            return driver;
        }
    }
}
