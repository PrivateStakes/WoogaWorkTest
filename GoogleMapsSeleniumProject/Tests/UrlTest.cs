using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace GoogleMapsSeleniumProject
{
    internal class UrlTest : TestEnvironment
    {
        public UrlTest()
        {
            url = "https://www.google.com/maps";
        }

        public override bool test_main(IWebDriver driver, string address)
        {
            bool result = false;
            driver.Url = _url;
            //driver.Navigate().GoToUrl()

            if (is_element_present(driver, By.ClassName("Nc7WLe")))
            {
                IWebElement decline_cookies = driver.FindElement(By.ClassName("Nc7WLe"));
                decline_cookies.Click();
            }
            
            System.Threading.Thread.Sleep(1000);

            IWebElement search_text = driver.FindElement(By.ClassName("tactile-searchbox-input"));
            search_text.SendKeys(address);
            driver.FindElement(By.CssSelector("[name = 'q']")).SendKeys(Keys.Enter);

            result = is_element_loaded(driver, By.ClassName("w6VYqd"));
            System.Threading.Thread.Sleep(1000);

            return result;
        }
    }
}
