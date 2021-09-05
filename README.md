
OS Used:
iOS

Tools Used:
Visual Studio

Language Used: C#

Framework : 
MS Test for developing the test scripts
Selenium WebDriver for UI Automation 
RestSharp for API Automation
ExtendReports for ReportGenerator library

NuGet Packages :
Below are common for Both UI and API Automation Projects
MSTest.Adapter
MSTest.Framewor
ReportGenerator - Class Library

Include below NuGet packages for API Automation Project:
RestSharp
RestSharp.Newtonsoft.Json

Include Below NuGet packages for UI Automation project:
Selenium.WebDriver
Selenium.WebDriver.ChromeDriver
Selenium.Support

Include below NuGet Package for ReportGenerator:
ExtentReports

Installation Steps:
Pre Requisite:
1. Visual Studio tool is must needed for the execution of Test Scripts
2. Chrome WebDriver is also needed.

Installation of Chrome Web Driver:
1. Download Chrome WebDriver (Latest Version is preferable) from site - https://sites.google.com/a/chromium.org/chromedriver/downloads
2. Download mac64_m1.zip if your mac has Apple Silicon M1 CPU otherwise select the mac64.zip version if your mac has Intel CPU. (Here I used mac64_m1.zip) 
3. Move the driver to the /usr/local/bin folder as it is defined as global path for Mac system.

Steps:
1. Open VisualStudio 
2. Open AutomationProject folder and open AutomationTask folder
3. Click on AutomationTask.sln file and open it in Visual Studio (AutomationProject-> AutomationTask->AutomationTask.sln)
4. Solution opens in Visual Studio and it will have three projects.
5. Install above mentioned NuGet packages as per project requirement(Refer below for Installation of NuGet Packages)
5. After installation of NuGet Packages, right click on AutomationTask and Click on Build option and Check that Build should be successful

Installation of NuGet Packages:
1. First Install ExtentReports for ReportGenerator Project
2. Right Click on ReportGenerator -> Select Manage NuGet Packages 
3. Browse for ExtentReports Package and Click on Add Package Option
4. After Successful installation, build the project

For APIAutomation Project: 
1. Expand the Project Folder (APIAutomation - > Dependencies)
2. Right Click on NuGet and Select Manage NuGet Packages
3. Browse for below Mentioned NuGet Packages and Select and Click on Add Package Option for each package
	•	RestSharp
	•	RestSharp.Newtonsoft.Json
	•	MSTest.Adapter
	•	MSTest.Framework
4. Installation should be successful
5. Add ReportGenerator class library. (Click on Dependencies - > Add References - >Under Projects Select ReportGenerator and Click Ok) 
6. A separate folder “Projects” will be created under Dependencies folder which will have ReportGenerator Package

For UIAutomation Project: 
1. Expand the Project Folder (UIAutomation - > Dependencies)
2. Right Click on NuGet and Select Manage NuGet Packages
3. Browse for below Mentioned NuGet Packages and Select and Click on Add Package Option for each package
	•	Selenium.WebDriver
	•	Selenium.WebDriver.ChromeDriver
	•	Selenium.Support
	•	MSTest.Adapter
	•	MSTest.Framework
4. Installation should be successful
5. Add ReportGenerator class library. (Click on Dependencies - > Add References - >Under Projects Select ReportGenerator and Click Ok) 
6. A separate folder “Projects” will be created under Dependencies folder which will have ReportGenerator Package

How to execute Test Scripts:
For API Automation:
1. Build the APIAutomation Project and Build should be success without any errors
2. Go to TestExplorer 
3. Under APIAutomation we can see two test cases
4. Right Click on Test case and Select Run Option
5. After Execution a html report will be generated with Test Execution Status and Information.

Note: We can find the HTML report under @ProjectFolder/obj/TestResults/index.html (for Example : file:///Users/chandu/Desktop/AutomationProject/AutomationTask/APIAutomation/obj/TestResults/index.html)

For UIAutomation:
1. Build the UIAutomation Project and Build should be success without any errors
2. Go to TestExplorer 
3. Under UIAutomation we can see three test cases
4. Right Click on Test case and Select Run Option
5. After Execution a html report will be generated with Test Execution Status and Information.

Note: 
1. We can find the HTML report under @ProjectFolder/obj/TestResults/index.html (for Example : ffile:///Users/chandu/Desktop/AutomationProject/AutomationTask/AutomationTask/obj/TestResults/index.html)
2. Here I have used Chrome Web Driver for testing.

Below are the results of all the test scripts:
APIAutomation:
Test Case 1:

￼

Test Case 2:

￼

UIAutomation:
 Test Case 1:

￼

Test Case 2:

This test method fails as selenium cannot capture the captcha images as it displays different images for different sessions
Alternative for checking this scenario is, asking developer to configure only one image for test environment and then automate the script with that image
Or need to test it manually

￼


TestCase 3:

￼








