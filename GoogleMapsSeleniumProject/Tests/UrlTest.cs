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


        public override bool test_main(IWebDriver driver, string address, ref bool cookies_google, ref bool cookies_maps, ref string error_exception)
        {
            bool result = false;
            driver.Url = url;
            IWebElement web_element;

            if (!cookies_maps) is_element_loaded(driver, By.Id("Nc7WLe"));
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

            return result;
        }
    }
}
