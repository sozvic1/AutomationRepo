using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation.Testing.Containers
{
    [TestClass]
    public class SeleniumSamples
    {
        [TestMethod]
        public void WebDriverSamples()
        {
            IWebDriver driver = new ChromeDriver();
            Thread.Sleep(1000);
        }
        [TestMethod]
        public void WebElementSamples()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
       
        }
        [TestMethod]
        public void WebDriverFactorySamples()
        {
            var driver = new WebDriverFactory(new DriverParams {Driver = "chrome",Binaries ="" }).Get();
            driver.Manage().Window.Maximize();

        }
    }
}
