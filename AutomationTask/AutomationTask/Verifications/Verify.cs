using System;
using System.Collections.Generic;
using System.Linq;
//using NUnit.Framework;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportGenerator;
using AventStack.ExtentReports;

namespace UIAutomation.Verifications
{
    public class Verify
    {
        /// <summary>
        /// Verifies the two strings
        /// </summary>
        /// <param name="value1">Value to be matched</param>
        /// <param name="value2">Value that need to be checked with string one</param>
        public static void VerifyValues(string value1, string value2)
        {
            try
            {
                if (value1.Contains(value2))
                {
                    Assert.IsTrue(true, value1 + " matches with " + value2);
                    Reporter.LogToReport(Status.Info, value1 + " matches with " + value2);
                }
                else
                {
                    Assert.Fail(value1 + " does not matches with " + value2);
                    Reporter.LogToReport(Status.Info, value1 + " does not matches with " + value2);
                }
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
                Reporter.LogToReport(Status.Fail, value1 + " does not matches with " + value2);
            }
        }

        /// <summary>
        /// Verifies the LInks with country codes
        /// </summary>
        /// <param name="links">List of Links</param>
        /// <param name="values">Country Values</param>
        public static void VerifyListOfLinks(List<string> links, List<string> values)
        {
            try
            {
                List<string> ints1 = links;
                List<string> ints2 = values;
                if (ints1.Count == ints2.Count)
                {
                    for (int i = 0; i < ints1.Count; i++)
                        if (ints1[i].Contains(ints2[i]))
                        {
                            Assert.IsTrue(true, links[i] + " matches with " + values[i]);
                            Reporter.LogToReport(Status.Info, links[i] + " matches with " + values[i]);
                        }
                        else
                        {
                            Assert.Fail(links[i] + " does not matches with " + values[i]);
                            Reporter.LogToReport(Status.Info, links[i] + " does not matches with " + values[i]);
                        }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Reporter.LogToReport(Status.Fail, "Links does not matches with Country Codes");
            }

        }
    }
}
