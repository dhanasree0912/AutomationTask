using System.Diagnostics;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using ReportGenerator;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace APIAutomation
{
    [TestClass]
    public class APIAutomationTests
    {
        //gets and sets the test context of the test method
        public TestContext TestContext { get; set; }

        //Initializes the class 
        [ClassInitialize]
        public static void SetUp(TestContext TestContext)
        {
            var dir = TestContext.TestRunDirectory;
            Reporter.SetUpExtentReporter("API Automation", "Automation Test report", dir);
        }
        //Initializes the test. Here test method name is returned for html report
        [TestInitialize]
        public void SetUpTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }

        //Test Metod for Verification of Country and State.
        //Pass or Fail Html Report along with information of Assertions after test execution
        
        [TestMethod]
        public void VerifyCountry_State()
        {
            try
            {
                //Stopwatch to verify reponse time of API
                Stopwatch reveil = new Stopwatch();
                reveil.Start();
                var test = new APIHelper();
                //Set the Url
                var Url = test.SetUrl("de/bw/stuttgart");
                //Create API request
                var request = test.CreateGetRequest();
                //Get API response
                var response = test.GetResponse(Url, request);
                reveil.Stop();
                long res = reveil.ElapsedMilliseconds;

                //Deserializing Json Content
                Root locationResponse = test.GetContent<Root>(response);


                var result = from e in locationResponse.places.ToList()
                             where e.PostCode == "70597" && e.latitude == "48.7496"
                             select e.PlaceName;

                //Assertions and Logging info and status to html report
                Assert.AreEqual(response.StatusCode.ToString(), "OK");
                Reporter.LogToReport(Status.Info, "Status Code is OK i.e. 200");
                Assert.AreEqual(response.ContentType.ToString(), "application/json");
                Reporter.LogToReport(Status.Info, "Content-Type is 'application/json'");
                Assert.IsTrue(res < 1000);
                Reporter.LogToReport(Status.Info, "response time is " + res + " which is less than 1s (1000ms)");
                Assert.AreEqual(locationResponse.country, "Germany");
                Reporter.LogToReport(Status.Info, "Country Name is Germany");
                Assert.AreEqual(locationResponse.state, "Baden-Württemberg");
                Reporter.LogToReport(Status.Info, "State Name is Baden-Württemberg");
                Assert.AreEqual(result.SingleOrDefault(), "Stuttgart Degerloch");
                Reporter.LogToReport(Status.Info, "For Post Code '70597', the place name has 'Stuttgart Degerloch'");
                Reporter.LogToReport(Status.Pass,"Test is Passed");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace + ex.Message);
                Reporter.LogToReport(Status.Fail, ex.StackTrace + ex.Message);
            }
        }

        //Data driven test method using XML
        //Get Country codes, Postal codes and City Names Data from xml
        //Test Metod for Verification of City Names for given Country and Postal Codes.
        //Pass or Fail Html Report along with information of Assertions after test execution

        [TestMethod]
        public void DataDrivenTestMethod()
        {
            try
            {
                // Get Country codes, Postal codes and City Names Data from xml
                List<List<string>> value = ReadDataFromXML("TestData.xml");
                //Stopwatch to verify reponse time of API
                Stopwatch reveil = new Stopwatch();
                reveil.Start();
                //for loop for looping different scenarios data from XML
                for (int i = 0; i <= 2; i++)
                {
                    List<string> country = value[i];
                    var test = new APIHelper();
                    //Set the Url with country and post code
                    var Url = test.SetUrl(country[0] + "/" + country[1]);
                    //Create API request
                    var request = test.CreateGetRequest();
                    //Get API response
                    var response = test.GetResponse(Url, request);
                    //Deserializing Json Content
                    Root locationResponse = test.GetContent<Root>(response);
                    //Assertions and Logging info and status to html report
                    Assert.AreEqual(response.StatusCode.ToString(), "OK");
                    Reporter.LogToReport(Status.Info, "Status Code is OK i.e. 200");
                    Assert.AreEqual(response.ContentType.ToString(), "application/json");
                    Reporter.LogToReport(Status.Info, "Content-Type is 'application/json'");
                    Assert.AreEqual(locationResponse.places[0].PlaceName.ToString(), country[2]);
                    Reporter.LogToReport(Status.Info, "Place Name is '" + country[2] + "' for Country '" + country[0] + "' and postal code '" + country[1] + "'");
                }
                reveil.Stop();
                long res = reveil.ElapsedMilliseconds;
                //Assertions and Logging info and status to html report
                Assert.IsTrue(res < 1000);
                Reporter.LogToReport(Status.Info, "response time is " +res+ " which is less than 1s (1000ms)");
                Reporter.LogToReport(Status.Pass, "Test is Passed");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace + ex.Message);
                Reporter.LogToReport(Status.Fail, ex.StackTrace + ex.Message);
            }

        }

        /// <summary>
        /// Reads data from TestData.XML
        /// </summary>
        /// <param name="FileName">Input file name </param>
        /// <returns>List containing Lists of Country Names,Postal Codes and City Names</returns>
        public static List<List<string>> ReadDataFromXML(string FileName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string _datafilePath = projectDirectory + "/TestData/" + FileName;
            XDocument xmlDoc = XDocument.Load(_datafilePath);
            var items = from item in xmlDoc.Descendants("CountryNames")
                        select new
                        {
                            CountryName1 = item.Elements("CountryName1").Descendants().Select(x => x.Value).ToList(),
                            CountryName2 = item.Elements("CountryName2").Descendants().Select(x => x.Value).ToList(),
                            CountryName3 = item.Elements("CountryName3").Descendants().Select(x => x.Value).ToList(),
                        };
            List<List<string>> myList = new List<List<string>>();
            myList.Add(new List<string>(items.Single().CountryName1));
            myList.Add(new List<string>(items.Single().CountryName2));
            myList.Add(new List<string>(items.Single().CountryName3));
            return myList;
        }

        // Executes after each test run and Logs test status of the test method
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
        }

        //Executes after execution of all test methods and generates Html report
        [ClassCleanup]
        public static void FlushTestReport()
        {
            ReportGenerator.Reporter.FlushReport();

        }
    }
}
