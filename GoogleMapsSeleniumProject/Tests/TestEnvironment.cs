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
        private string _url;
        
        public abstract bool test_main(IWebDriver driver, string address, ref bool cookies_google, ref bool cookies_maps, ref string error_exception);

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
        

        protected void click_on_element(IWebDriver driver, By conditions) //not the most effective way of doing it, but it gets the job done
        {
            IWebElement decline_cookies = driver.FindElement(conditions);
            decline_cookies.Click();
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
            int timeout = 5;

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
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
