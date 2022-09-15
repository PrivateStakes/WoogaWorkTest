using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GoogleMapsSeleniumProject
{
    internal class SearchTest : TestEnvironment
    {
        public SearchTest()
        {
            url = "https://www.google.com";
        }


        public override bool test_main(IWebDriver driver, string address, ref bool cookies_google, ref bool cookies_maps, ref string error_exception)
        {
            bool result = false;
            driver.Url = url;
            IWebElement web_element;

            if (!cookies_google) is_element_loaded(driver, By.Id("W0wltc"));
            if (is_element_present(driver, By.Id("W0wltc")))
            {
                click_on_element(driver, By.Id("W0wltc"));   //decline cookies
                cookies_google = true;
            }

            System.Threading.Thread.Sleep(1000);

            web_element = driver.FindElement(By.CssSelector("[name = 'q']"));
            web_element.SendKeys("google maps");

            driver.FindElement(By.CssSelector("[name = 'q']")).SendKeys(Keys.Enter);

            System.Threading.Thread.Sleep(1000);

            if (is_element_present(driver, By.ClassName("LC20lb"))) //selects the 'google maps' search result
            {
                click_on_element(driver, By.ClassName("LC20lb"));

                if (!cookies_maps) is_element_loaded(driver, By.ClassName("Nc7WLe"));
                if (is_element_present(driver, By.ClassName("Nc7WLe")))
                {
                    click_on_element(driver, By.ClassName("Nc7WLe"));   //decline cookies
                    cookies_maps = true;
                }

                System.Threading.Thread.Sleep(1000);

                string class_name = "";
                if (is_element_present(driver, By.ClassName("searchboxinput"))) class_name = "searchboxinput";
                if (is_element_present(driver, By.ClassName("tactile-searchbox-input"))) class_name = "tactile-searchbox-input";

                if (class_name != "")
                {
                    web_element = driver.FindElement(By.ClassName(class_name));
                    web_element.SendKeys(address);
                    driver.FindElement(By.CssSelector("[name = 'q']")).SendKeys(Keys.Enter);

                    result = is_element_loaded(driver, By.ClassName("w6VYqd"));
                    System.Threading.Thread.Sleep(4000);
                }
                else error_exception = "was unable to find the search bar in google maps";
            }
            else error_exception = "was unable to find 'google maps' in the search results";

            return result;
        }
    }
}
