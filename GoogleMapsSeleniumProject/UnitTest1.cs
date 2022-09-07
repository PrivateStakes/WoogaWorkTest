using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;

namespace GoogleMapsSeleniumProject
{

    /*
     * disable cookies for..
     
     Chrome:
       prefs.put("network.cookie.cookieBehavior", 2);
     
    Firefox:
       profile.setPreference("network.cookie.cookieBehavior", 2);
     */

    public class Tests
    {
        string maps_url = "https://www.google.com";

        IWebDriver driver;

        [SetUp] //prepare variables for the tests (constructors and whatnot)

        public void start_browser()
        {
            //Selenium WebDriver set to utilised broswer (make one for each browser later)
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments(@"--user-data-dir=C:\Users\your username\AppData\Local\Google\Chrome\User Data");

            //web_driver = new ChromeDriver(options);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]  //all test methods you are planning to utilise (runtime)
        //public void Test1()
        //{
        //    Assert.Pass();
        //}
        public void test_search()
        {
            driver.Url = maps_url;
            //driver.Navigate().GoToUrl()

            System.Threading.Thread.Sleep(2000); //change to deny cookies "W0wltc"

            IWebElement searchButton = driver.FindElement(By.Id("W0wltc"));
            searchButton.Click();

            System.Threading.Thread.Sleep(2000);

            
            //prefs.put("network.cookie.cookieBehavior", 2);    

            IWebElement searchText = driver.FindElement(By.CssSelector("[name = 'q']"));

            searchText.SendKeys("cheese");

            

            // Actions builder = new Actions(driver);
            //builder.SendKeys(Keys.Enter);

            driver.FindElement(By.CssSelector("[name = 'q']")).SendKeys(Keys.Enter);

            //IWebElement searchButton = web_driver.FindElement(By.XPath("//div[@class='FPdoLc tfB0Bf']//input[@name='btnK']"));

            // searchButton.Click();

        }

        [TearDown]  //what you want to do at the end of the test (destructors and whatnot)
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}