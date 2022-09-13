using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace GoogleMapsSeleniumProject
{
    internal class SearchTest : TestEnvironment
    {
        public SearchTest()
        {
            url = "https://www.google.com";
        }


        public override bool test_main(IWebDriver driver, string address)
        {
            bool result = false;
            driver.Url = _url;
            //driver.Navigate().GoToUrl()

            System.Threading.Thread.Sleep(1000); //change to deny cookies "W0wltc"

            if (is_element_present(driver, By.Id("W0wltc")))
            {
                IWebElement declineCookies = driver.FindElement(By.Id("W0wltc"));
                declineCookies.Click();
            }
            

            System.Threading.Thread.Sleep(1000);


            //prefs.put("network.cookie.cookieBehavior", 2);    

            IWebElement search_text = driver.FindElement(By.CssSelector("[name = 'q']"));
            search_text.SendKeys("google maps");

            driver.FindElement(By.CssSelector("[name = 'q']")).SendKeys(Keys.Enter);

            System.Threading.Thread.Sleep(1000);

            //hdtb-mitem
            if (is_element_present(driver, By.Id("rso")))
            {
                IWebElement enter_google_maps = driver.FindElement(By.Id("rso"));
                enter_google_maps.Click();

                System.Threading.Thread.Sleep(1000);

                if (driver.Url == "https://www.google.com/maps" && is_element_present(driver, By.ClassName("tactile-searchbox-input")))
                {
                    search_text = driver.FindElement(By.ClassName("tactile-searchbox-input"));
                    search_text.SendKeys(address);
                    driver.FindElement(By.CssSelector("[name = 'q']")).SendKeys(Keys.Enter);

                    result = is_element_loaded(driver, By.ClassName("m6QErb"));
                    System.Threading.Thread.Sleep(1000);
                }
                else result = false;
            }
            else result = false;

            return result;

            //Actions builder = new Actions(driver);
            //builder.SendKeys(Keys.Enter);

        }
    }
}
