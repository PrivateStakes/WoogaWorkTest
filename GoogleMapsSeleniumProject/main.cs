using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Interactions;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System.Collections.Generic;


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
        private IWebDriver _driver;
        private List<TestEnvironment> _tests;

        [SetUp] //prepare variables for the tests (constructors and whatnot)

        public void start_browser()
        {
            _tests = new List<TestEnvironment>();

            _tests.Add(new UrlTest());
            _tests.Add(new SearchTest());
            _tests.Add(new MenuTest());

            //Selenium WebDriver set to utilised broswer (make one for each browser later)
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments(@"--user-data-dir=C:\Users\your username\AppData\Local\Google\Chrome\User Data");

            //web_driver = new ChromeDriver(options);

            //ICapabilities capabilities = ((RemoteWebDriver)_driver).Capabilities;


        }

        [Test]  //all test methods you are planning to utilise (runtime)
        //public void Test1()
        //{
        //    Assert.Pass();
        //}
        public void test_search()
        {
            for (int j = 0; j < 2; j++) //iterate through the different browsers -- may have to be made into a switch case if language cannot be made universal
            {
                switch (j)  //skip enums for now
                {
                    case 0: //Chrome
                        new DriverManager().SetUpDriver(new ChromeConfig(), "104.0.5112.79");    //, capabilities.GetCapability("browserVersion").ToString()
                        _driver = new ChromeDriver();
                        _driver.Manage().Window.Maximize();

                        break;

                    case 1: //Edge
                        _driver.Close();
                        new DriverManager().SetUpDriver(new EdgeConfig());    //, capabilities.GetCapability("browserVersion").ToString()
                        _driver = new EdgeDriver();
                        _driver.Manage().Window.Maximize();
                        break;

                    case 2: //FireFox
                        
                        _driver.Close();
                        new DriverManager().SetUpDriver(new FirefoxConfig());    //, capabilities.GetCapability("browserVersion").ToString()
                        _driver = new FirefoxDriver();
                        _driver.Manage().Window.Maximize();
                        System.Threading.Thread.Sleep(3000);
                        break;

                    case 4: //Safari
                        _driver.Close();
                        _driver = new SafariDriver();   //does it not need to be set up?
                        _driver.Manage().Window.Maximize();
                        System.Threading.Thread.Sleep(3000);
                        break;

                    case 5: //Opera - do last
                        break;

                    default:
                        Assert.IsTrue(false, "Program tried to use a non-existant browser");
                        break;
                }

                foreach (var test in _tests)
                {
                    test.test_main(_driver);
                }
            }

            
            _driver.FindElement(By.CssSelector("[name = 'q']")).SendKeys(Keys.Enter);

            //IWebElement searchButton = web_driver.FindElement(By.XPath("//div[@class='FPdoLc tfB0Bf']//input[@name='btnK']"));

            // searchButton.Click();

        }

        [TearDown]  //what you want to do at the end of the test (destructors and whatnot)
        public void close_Browser()
        {
            _driver.Quit();
        }
    }
}