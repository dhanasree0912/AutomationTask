using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace UIAutomation.WebElements
{
    public class WebElements
    {
        //Home Page Elements
        public static string AcceptCookies = "//*[@id='CookieConsent']/div[1]/div/div[2]/div[2]/button[1]";
        public static string ServicesOption = "//*[@id='main-menu']/ul/li[3]/div[1]/span";
        public static string AutomationOption = "//*[@id='main-menu']/ul/li[3]/div[2]/ul/li[4]";
        public static string ServiceOptionSelected = "//*[@id='main-menu']/ul/li[3]";
        public static string AutomationOptionSelected = "//*[@id='main-menu']/ul/li[3]/div[2]/ul/li[4]";


        //Automation Page Elements
        public static string AutomationHeader = "//*[@id='primary_content']/div/div[2]/div/h1/span";
        public static string FirstNameTextBx = "//*[@id='4ff2ed4d-4861-4914-86eb-87dfa65876d8']";
        public static string LastNameTextBx = "//*[@id='11ce8b49-5298-491a-aebe-d0900d6f49a7']";
        public static string EmailTextBx = "//*[@id='056d8435-4d06-44f3-896a-d7b0bf4d37b2']";
        public static string PhoneTextBx = "//*[@id='755aa064-7be2-432b-b8a2-805b5f4f9384']";
        public static string CompanyTextBx = "//*[@id='703dedb1-a413-4e71-9785-586d609def60']";
        public static string CountryDropDwn = "//*[@id='e74d82fb-949d-40e5-8fd2-4a876319c45a']";
        public static string MessageTextBx = "//*[@id='88459d00-b812-459a-99e4-5dc6eff2aa19']";
        public static string AgreeCheckBx = "//*[@id='863a18ee-d748-4591-bb64-ef6eae65910e']/fieldset/label/input";
        public static string CaptchaChckBx = "//*[@id='recaptcha-anchor']";
        public static string SubmitBtn = "//*[@id='06838eea-8980-4305-83d0-42236fb4d528']";
        public static string SuccessMessage = "//*[@id='99a12a58-3899-4fe1-a5c7-b9065fe635b0']/div[1]/div";

        public static string WorldWideLink =  "//*[@id='header']/div[2]/div/div[2]/div[2]/div[2]/span";
        public static List<string> CountryNames = new List<string>{"com", "us", "uk", "se", "es", "no", "nl", "lu", "ie", "de", "fr", "fi", "be" };
       
    }
}
