using OpenQA.Selenium;
using UIAutomation.Utilities;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AventStack.ExtentReports;
using ReportGenerator;

namespace UIAutomation
{

    [TestClass]
    public class UIAutomationTests : BaseClass.BaseClass
    {
        //gets and sets the test context of the test method
        public TestContext TestContext { get; set; }


        static IWebDriver driver;
        private static WebDriverWait wait;

        static string test_url = "https://www.sogeti.com/";

        //Initializes the class 
        [ClassInitialize]
        public static void SetUp(TestContext TestContext)
        {
            var dir = TestContext.TestRunDirectory;
            Reporter.SetUpExtentReporter("UI Automation", "Automation Test report", dir);
        }
        //Initializes the test. Here test method name is returned for html report
        [TestInitialize]
        public void SetUpTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }

        //Verifies the Services Option and Automation page
        [TestMethod]
        public void TestCase1()
        {
            try
            {
                Reporter.LogToReport(Status.Info, "Verifies the Services Option and Automation page");
                driver = BaseClassDriver();    
                UIActions.HoverElement(driver, WebElements.WebElements.ServicesOption);
                UIActions.ClickByXpath(driver, WebElements.WebElements.AutomationOption);
                Verifications.Verify.VerifyValues(driver.Url.ToString(), "automation");
                Verifications.Verify.VerifyValues(driver.FindElement(By.XPath(WebElements.WebElements.AutomationHeader)).Text, "Automation");
                Reporter.LogToReport(Status.Info, "Automation Screen is displayed and Automation is displayed");
                UIActions.HoverElement(driver, WebElements.WebElements.ServicesOption);
                Verifications.Verify.VerifyValues(driver.FindElement(By.XPath(WebElements.WebElements.ServiceOptionSelected)).GetAttribute("class"), "selected");
                Verifications.Verify.VerifyValues(driver.FindElement(By.XPath(WebElements.WebElements.AutomationOptionSelected)).GetAttribute("class"), "selected");
                Reporter.LogToReport(Status.Info, "Services and Automation options are selected");
                Reporter.LogToReport(Status.Pass, "Passed");

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
                Reporter.LogToReport(Status.Fail, ex.StackTrace);

            }
        }

        //this test method fails as selenium cannot capture the captcha images as it displays different images for different sessions
        //Alternative for checking this is asking developer to configure only one image for test environment and then automate the script with that image
        //Or need to test it manually
        [TestMethod]
        public void TestCase2()
        {
            try
            {
                Reporter.LogToReport(Status.Info, "Verifies the submission of automation contact us form");
                driver = BaseClassDriver();
                UIActions.HoverElement(driver, WebElements.WebElements.ServicesOption);
                UIActions.ClickByXpath(driver, WebElements.WebElements.AutomationOption);
                UIActions.EnterText(driver, WebElements.WebElements.FirstNameTextBx, UIActions.RandomString(8));
                UIActions.EnterText(driver, WebElements.WebElements.LastNameTextBx, UIActions.RandomString(8));
                UIActions.EnterText(driver, WebElements.WebElements.EmailTextBx, UIActions.RandomString(8) + "@gmail.com");
                UIActions.EnterText(driver, WebElements.WebElements.PhoneTextBx, UIActions.RandomNumber());
                UIActions.EnterText(driver, WebElements.WebElements.CompanyTextBx, "Company");
                UIActions.EnterDropDwnValue(driver, WebElements.WebElements.CountryDropDwn, "Germany");
                UIActions.EnterText(driver, WebElements.WebElements.MessageTextBx, UIActions.RandomString(25));
                UIActions.SelectCheckBox(driver, WebElements.WebElements.AgreeCheckBx);
                // UIActions.SelectCheckBox(driver, WebElements.WebElements.CaptchaChckBx);
                UIActions.ClickByXpath(driver, WebElements.WebElements.SubmitBtn);
                Verifications.Verify.VerifyValues(driver.FindElement(By.XPath(WebElements.WebElements.SuccessMessage)).GetAttribute("class"), "Success");
                ReportGenerator.Reporter.LogToReport(Status.Pass, "Passed");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
                ReportGenerator.Reporter.LogToReport(Status.Fail, ex.StackTrace);

            }
        }

        //Verifies all country specific sogeti links are working 
        [TestMethod]
        public void TestCase3()
        {
            try
            {
                Reporter.LogToReport(Status.Info, "Verifies all country specific sogeti links are working");
                driver = BaseClassDriver();
                UIActions.ClickByXpath(driver, WebElements.WebElements.WorldWideLink);
                List<string> links = UIActions.ClickMultipleLinks(driver, 12);
                Verifications.Verify.VerifyListOfLinks(links, WebElements.WebElements.CountryNames);
                ReportGenerator.Reporter.LogToReport(Status.Pass, "Passed");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
                ReportGenerator.Reporter.LogToReport(Status.Fail, ex.StackTrace);

            }
        }

        // Executes after each test run and Logs test status of the test method
        //Quits the driver after completing the test execution
        [TestCleanup]
        public void TearDown()
        {

            var testStatus = TestContext.CurrentTestOutcome;
            Status logStatus;

            switch (testStatus)

            {
                case UnitTestOutcome.Failed:
                    logStatus = Status.Fail;
                    ReportGenerator.Reporter.TestStatus(logStatus.ToString());
                    break;
                case UnitTestOutcome.Passed:
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
                default:
                    break;
            }
            driver.Quit();
        }

        //Executes after execution of all test methods and generates Html report
        [ClassCleanup]
        public static void FlushTestReport()
        {
            ReportGenerator.Reporter.FlushReport();

        }
    }
}
