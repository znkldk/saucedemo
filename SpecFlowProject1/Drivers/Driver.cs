
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace SpecFlowProject1.Drivers
{
    [Binding]
    public class Driver
    {
        public static IWebDriver webDriver = new ChromeDriver("C:\\Users\\Barış\\RiderProjects\\SeleniumTest\\SpecFlowProject1");

        [BeforeScenario]
        public void beforeTest()
        {
            webDriver.Navigate().GoToUrl("https://www.saucedemo.com/");

        }
        
        [AfterScenario]
        public void afterTest()
        {
            webDriver.Quit();
        }

    }
    
}