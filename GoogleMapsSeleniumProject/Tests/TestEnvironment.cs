using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SeleniumExtras;

namespace GoogleMapsSeleniumProject
{
    abstract class TestEnvironment
    {
        protected string _url;

        
        public abstract bool test_main(IWebDriver driver, string address);

        protected string url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        protected bool is_element_present(IWebDriver driver, By conditions)
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


        protected bool  is_element_loaded(IWebDriver driver, By conditions)
        {
            int timeout = 10;

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(conditions));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
