using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsSeleniumProject
{
    internal class GoogleTest : TestEnvironment
    {
        public GoogleTest()
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
                click_on_element(driver, By.Id("W0wltc")); //decline cookies
                cookies_google = true;
            }

            System.Threading.Thread.Sleep(1000);

            web_element = driver.FindElement(By.CssSelector("[name = 'q']"));
            web_element.SendKeys(address);

            driver.FindElement(By.CssSelector("[name = 'q']")).SendKeys(Keys.Enter);

            string id_or_class_name = "";
            is_element_loaded(driver, By.CssSelector("[name = 'q']"));
            System.Threading.Thread.Sleep(1000);
            
            if (is_element_present(driver, By.ClassName("w7Dbne"))) id_or_class_name = "w7Dbne";
            else if (is_element_present(driver, By.ClassName("adgvqc"))) id_or_class_name = "adgvqc";
            else if (is_element_present(driver, By.ClassName("GosL7d"))) id_or_class_name = "GosL7d";

            if (id_or_class_name != "")
            {
                click_on_element(driver, By.ClassName(id_or_class_name));

                if (is_element_present(driver, By.ClassName("v7W49e"))) result = is_element_loaded(driver, By.ClassName("v7W49e"));
                else if (is_element_present(driver, By.ClassName("w6VYqd"))) result = is_element_loaded(driver, By.ClassName("w6VYqd"));
                else error_exception = "connection timed out(?): reached google maps but was unable to secure the address being reached";
                System.Threading.Thread.Sleep(4000);
            }
            else error_exception = "was unable to find access to google maps (result did not yield an address)";

            return result;
        }
    }
}
