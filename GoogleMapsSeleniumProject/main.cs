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


//using OpenQA.Selenium.Opera;

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
        private enum E_Browsers
        {
            google_chrome,
            microsoft_edge,
            mozilla_firefox,
            apple_safari,
            opera_opera,
            last_element //note: this element should ALWAYS be the last element
        };

        private IWebDriver _driver;
        private List<TestEnvironment> _tests;
        private List<String> _addresses;
        private List<String> _coordinates;
        private DriverManager _web_driver_manager;

        [SetUp]
        public void start_browser()
        {
            _tests = new List<TestEnvironment>();
            _addresses = new List<String>();
            _web_driver_manager = new DriverManager();

            _tests.Add(new UrlTest());
            _tests.Add(new SearchTest());
            _tests.Add(new MenuTest());        

            //load data
            string[] address_data = System.IO.File.ReadAllLines(@"..\..\..\addresses.txt");

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of tst.txt = ");
            foreach (string line in address_data)
            {
                if (line != "") _addresses.Add(line);
            }
        }

        //Assert.Pass();
        [Test]
        public void test_search()
        {
            for (int j = 0; j < (int)E_Browsers.last_element + 1; j++) //iterate through the different browsers -- may have to be made into a switch case if language cannot be made universal
            {
                switch ((E_Browsers)j)
                {
                    case E_Browsers.google_chrome:
                        _web_driver_manager.SetUpDriver(new ChromeConfig(), "104.0.5112.79");    //, capabilities.GetCapability("browserVersion").ToString()
                        _driver = new ChromeDriver();
                        break;

                    case E_Browsers.microsoft_edge:
                        _web_driver_manager.SetUpDriver(new EdgeConfig());    //, capabilities.GetCapability("browserVersion").ToString()
                        _driver = new EdgeDriver();
                        break;

                    case E_Browsers.mozilla_firefox:
                        _web_driver_manager.SetUpDriver(new FirefoxConfig());    //, capabilities.GetCapability("browserVersion").ToString()
                        _driver = new FirefoxDriver();
                        break;

                    case E_Browsers.apple_safari:
                        break;

                    case E_Browsers.opera_opera:
                        break;

                    default:
                        Assert.IsTrue(false, "Program tried to use a non-existant browser");
                        break;
                }
                if (_driver != null)
                {
                    _driver.Manage().Window.Maximize();
                    foreach (var test in _tests)
                    {
                        for (int i = 0; i < _addresses.Count; i++)
                        {
                            Assert.IsTrue(test.test_main(_driver, _addresses[i]), "Test failed, could not navigate to address on Google Maps"); ;
                        }
                    }
                    _driver.Close();
                }
            }
        }

        [TearDown]  //what you want to do at the end of the test (destructors and whatnot)
        public void close_Browser()
        {
            _driver.Quit();
        }
    }
}