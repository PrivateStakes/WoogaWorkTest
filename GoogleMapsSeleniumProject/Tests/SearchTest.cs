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
            set_url("https://www.google.com");
        }

        public override void test_main(IWebDriver driver)
        {
            driver.Url = _url;
            //driver.Navigate().GoToUrl()

            System.Threading.Thread.Sleep(1000); //change to deny cookies "W0wltc"

            if (IsElementPresent(driver, By.Id("W0wltc")))
            {
                IWebElement declineCookies = driver.FindElement(By.Id("W0wltc"));
                declineCookies.Click();
            }
            

            System.Threading.Thread.Sleep(1000);


            //prefs.put("network.cookie.cookieBehavior", 2);    

            IWebElement searchText = driver.FindElement(By.CssSelector("[name = 'q']"));

            searchText.SendKeys("google maps");

            System.Threading.Thread.Sleep(3000);

            //Actions builder = new Actions(driver);
            //builder.SendKeys(Keys.Enter);

        }
    }
}
