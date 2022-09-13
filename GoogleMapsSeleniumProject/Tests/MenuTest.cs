using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace GoogleMapsSeleniumProject
{
    internal class MenuTest : TestEnvironment
    {
        public MenuTest()
        {
            url = "https://www.google.com";
        }


        public override bool test_main(IWebDriver driver, string address)
        {
            return true;
        }
    }
}
