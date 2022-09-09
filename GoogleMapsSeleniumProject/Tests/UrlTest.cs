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
            set_url("https://www.google.com/maps");
        }

        public override void test_main(IWebDriver driver)
        {
            driver.Url = _url;
            //driver.Navigate().GoToUrl()

            System.Threading.Thread.Sleep(1000); //change to deny cookies "W0wltc"

            if (IsElementPresent(driver, By.ClassName("Nc7WLe")))
            {
                IWebElement declineCookies = driver.FindElement(By.ClassName("Nc7WLe"));
                declineCookies.Click();
            }
            
            System.Threading.Thread.Sleep(3000);
        }
    }
}
