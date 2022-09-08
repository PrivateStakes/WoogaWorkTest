using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace GoogleMapsSeleniumProject
{
    abstract class TestEnvironment
    {
        protected IWebDriver _driver;
        protected string _url;

        public abstract void test_setup();

        public abstract void test_main();

        public IWebDriver get_web_driver()
        {
            return _driver;
        }

        public void set_web_driver(IWebDriver driver)
        {
            _driver = driver;
        }

        public string get_url()
        {
            return _url;
        }

        protected void set_url(string url)
        {
            _url = url;
        }
    }
}
