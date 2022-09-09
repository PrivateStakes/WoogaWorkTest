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
            set_url("https://www.google.com");
        }

        public override void test_main(IWebDriver driver)
        {

        }
    }
}
