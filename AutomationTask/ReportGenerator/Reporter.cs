using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace ReportGenerator
{
    public static class Reporter
    {
        public static ExtentReports extentReports;
        public static ExtentHtmlReporter extentHtmlReporter;
        public static ExtentTest extentTestCase;

        /// <summary>
        /// Setup the Html report 
        /// </summary>
        /// <param name="reportName">report name</param>
        /// <param name="docTitle">document title</param>
        /// <param name="path">path for saving the report</param>
        public static void SetUpExtentReporter(string reportName, string docTitle, dynamic path)
        {
            extentHtmlReporter = new ExtentHtmlReporter(path);
            extentHtmlReporter.Config.Theme = Theme.Standard;
            extentHtmlReporter.Config.DocumentTitle = docTitle;
            extentHtmlReporter.Config.ReportName = reportName;
            extentReports = new ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
        }

        /// <summary>
        /// Creates the test name of the test method
        /// </summary>
        /// <param name="testName">test name</param>
        public static void CreateTest(string testName)
        {
            extentTestCase = extentReports.CreateTest(testName);
        }
        /// <summary>
        /// Logs the results to html report
        /// </summary>
        /// <param name="status">status of the test case execution</param>
        /// <param name="message">customised message</param>

        public static void LogToReport(Status status, string message)
        {
            extentTestCase.Log(status, message);
        }

        /// <summary>
        /// test case status
        /// </summary>
        /// <param name="status">test case status</param>
        public static void TestStatus(string status)
        {
            if(status.Equals("Pass"))
            {
                extentTestCase.Pass("Test is Passed");
            }
            else
            {
                extentTestCase.Pass("Test is Failed");
            }
        }
        /// <summary>
        /// Generates html report
        /// </summary>
        public static void FlushReport()
        {
            extentReports.Flush();
        }
    }
}
