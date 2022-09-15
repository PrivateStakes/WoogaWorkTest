using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GoogleMapsSeleniumProject
{
    internal class MenuTest : TestEnvironment
    {
        public MenuTest()
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

            click_on_element(driver, By.ClassName("gb_z")); //click drop-down menu

            System.Threading.Thread.Sleep(1000);

            string google_maps_selector = "//*[@id='yDmH0d']/c-wiz/div/div/c-wiz/div/div/ul[1]/li[3]/a";
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id='gb']/div/div[3]/iframe")));

            if (is_element_present(driver, By.XPath(google_maps_selector))) //clicks on google maps through the drop-down menu
            {
                click_on_element(driver, By.XPath(google_maps_selector));   //enter google maps

                driver.SwitchTo().DefaultContent();

                if (!cookies_maps) is_element_loaded(driver, By.Id("Nc7WLe"));
                if (is_element_present(driver, By.ClassName("Nc7WLe")))
                {
                    click_on_element(driver, By.ClassName("Nc7WLe"));   //decline cookies
                    cookies_maps = true;
                }

                is_element_loaded(driver, By.ClassName("tactile-searchbox-input"));
                is_element_loaded(driver, By.ClassName("searchboxinput"));

                string class_name = "";
                if (is_element_present(driver, By.ClassName("searchboxinput"))) class_name = "searchboxinput";
                if (is_element_present(driver, By.ClassName("tactile-searchbox-input"))) class_name = "tactile-searchbox-input";

                if (class_name != "")
                {
                    web_element = driver.FindElement(By.ClassName(class_name));
                    web_element.SendKeys(address);
                    driver.FindElement(By.CssSelector("[name = 'q']")).SendKeys(Keys.Enter);

                    result = is_element_loaded(driver, By.ClassName("w6VYqd"));
                    System.Threading.Thread.Sleep(1000);
                }
                else error_exception = "was unable to find the search bar in google maps";
            }
            else
            {
                driver.SwitchTo().DefaultContent();
                error_exception = "was unable to enter google maps through the drop-down menu";
            }

            return result;
        }
    }
}
