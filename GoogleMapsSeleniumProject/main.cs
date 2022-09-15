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
    public class GoogleMapsTests
    {
        private enum E_Browsers
        {
            google_chrome,
            microsoft_edge,
            mozilla_firefox,
            //apple_safari, //note: these do not work
            //opera_opera,
            last_element    //note: this element should ALWAYS be the last element
        };

        private IWebDriver _driver;
        private List<TestEnvironment> _tests;
        private List<String> _addresses;
        private DriverManager _web_driver_manager;

        [SetUp]
        public void setup_tests()
        {
            _tests = new List<TestEnvironment>();
            _addresses = new List<String>();
            _web_driver_manager = new DriverManager();

            _tests.Add(new GoogleTest());
            _tests.Add(new UrlTest());
            _tests.Add(new SearchTest());
            _tests.Add(new MenuTest());

            //load data
            string[] address_data = System.IO.File.ReadAllLines(@"..\..\..\addresses.txt");
            /*I will refrain from having this cause an exception when no file exists, as it's better
             * to have it crash and know how to ammend it as a user, than to have the program do no-
             * -thing and be unsure as to what steps to take.*/

            System.Console.WriteLine("Contents of tst.txt = ");
            foreach (string line in address_data)
            {
                if (line != "") _addresses.Add(line);
            }
        }

        [Test]
        public void test_search()
        {
            bool tests_succeeded = true;
            string error_exception = "";
            string error_browser = "";
            string error_address = "";
            string error_test = "";

            for (int j = 0; j < (int)E_Browsers.last_element; j++)
            {
                bool cookies_disabled_google = false;
                bool cookies_disabled_maps = false;

                set_browser(j, ref error_browser);

                if (_driver != null)
                {
                    _driver.Manage().Window.Maximize();
                    foreach (var test in _tests)
                    {
                        for (int i = 0; i < _addresses.Count; i++)
                        {
                            if (!test.test_main(_driver, _addresses[i], ref cookies_disabled_google, ref cookies_disabled_maps, ref error_exception))
                            {
                                tests_succeeded = false;
                                error_address = _addresses[i];
                                error_test = test.GetType().Name;
                            }
                        }
                    }
                    _driver.Close();
                }
            }

            if (tests_succeeded) Assert.Fail("Test failed, could not navigate to address(" + error_address + ") in test " + error_test + " using the browser " + error_browser + ". Error report: " + error_exception);
        }

        [Test]
        public void test_google_test()
        {
            GoogleTest test = new GoogleTest();

            string error_exception = "";
            string error_browser = "";

            for (int j = 0; j < (int)E_Browsers.last_element; j++)
            {
                bool cookies_disabled_google = false;
                bool cookies_disabled_maps = false;

                set_browser(j, ref error_browser);
                if (_driver != null)
                {
                    for (int i = 0; i < _addresses.Count; i++)
                    {
                        if (!test.test_main(_driver, _addresses[i], ref cookies_disabled_google, ref cookies_disabled_maps, ref error_exception)) Assert.Fail("Test failed, could not navigate to address(" + _addresses[i] + ") in test " + test.GetType().Name + " using the browser " + error_browser + ". Error report: " + error_exception);
                    }
                    _driver.Close();
                }
            }
        }

        [Test]
        public void test_url_test()
        {
            UrlTest test = new UrlTest();

            string error_exception = "";
            string error_browser = "";

            for (int j = 0; j < (int)E_Browsers.last_element; j++)
            {
                bool cookies_disabled_google = false;
                bool cookies_disabled_maps = false;

                set_browser(j, ref error_browser);
                if (_driver != null)
                {
                    for (int i = 0; i < _addresses.Count; i++)
                    {
                        if (!test.test_main(_driver, _addresses[i], ref cookies_disabled_google, ref cookies_disabled_maps, ref error_exception)) Assert.Fail("Test failed, could not navigate to address(" + _addresses[i] + ") in test " + test.GetType().Name + " using the browser " + error_browser + ". Error report: " + error_exception);
                    }
                    _driver.Close();
                }
            }
        }

        [Test]
        public void test_search_test()
        {
            SearchTest test = new SearchTest();

            string error_exception = "";
            string error_browser = "";

            for (int j = 0; j < (int)E_Browsers.last_element; j++)
            {
                bool cookies_disabled_google = false;
                bool cookies_disabled_maps = false;

                set_browser(j, ref error_browser);
                if (_driver != null)
                {
                    for (int i = 0; i < _addresses.Count; i++)
                    {
                        if (!test.test_main(_driver, _addresses[i], ref cookies_disabled_google, ref cookies_disabled_maps, ref error_exception)) Assert.Fail("Test failed, could not navigate to address(" + _addresses[i] + ") in test " + test.GetType().Name + " using the browser " + error_browser + ". Error report: " + error_exception);
                    }
                    _driver.Close();
                }
            }
        }

        [Test]
        public void test_menu_test()
        {
            MenuTest test = new MenuTest();

            string error_exception = "";
            string error_browser = "";

            for (int j = 0; j < (int)E_Browsers.last_element; j++)
            {
                bool cookies_disabled_google = false;
                bool cookies_disabled_maps = false;

                set_browser(j, ref error_browser);
                if (_driver != null)
                {
                    for (int i = 0; i < _addresses.Count; i++)
                    {
                        if (!test.test_main(_driver, _addresses[i], ref cookies_disabled_google, ref cookies_disabled_maps, ref error_exception)) Assert.Fail("Test failed, could not navigate to address(" + _addresses[i] + ") in test " + test.GetType().Name + " using the browser " + error_browser + ". Error report: " + error_exception);
                    }
                    _driver.Close();
                }
            }
        }


        private void set_browser(int j, ref string error_browser)
        {
            switch ((E_Browsers)j)
            {
                case E_Browsers.google_chrome:
                    _web_driver_manager.SetUpDriver(new ChromeConfig(), "104.0.5112.79");
                    _driver = new ChromeDriver();
                    error_browser = "Google Chrome";
                    break;

                case E_Browsers.microsoft_edge:
                    _web_driver_manager.SetUpDriver(new EdgeConfig());
                    _driver = new EdgeDriver();
                    error_browser = "Microsoft Edge";
                    break;

                case E_Browsers.mozilla_firefox:
                    _web_driver_manager.SetUpDriver(new FirefoxConfig());
                    _driver = new FirefoxDriver();
                    error_browser = "Mozilla Firefox";
                    break;

                default:
                    Assert.Fail("Program tried to use a non-existant browser");
                    break;
            }
        }

        [TearDown]
        public void close_Browser()
        {
            _driver.Quit();
        }
    }
}