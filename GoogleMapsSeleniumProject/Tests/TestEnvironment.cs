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
        protected string _url;

        public abstract void test_main(IWebDriver driver);

        public string get_url()
        {
            return _url;
        }

        protected void set_url(string url)
        {
            _url = url;
        }

        protected bool IsElementPresent(IWebDriver driver, By conditions)
        {
            try
            {
                driver.FindElement(conditions);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
