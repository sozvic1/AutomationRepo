﻿using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Components
{
    public  class FluentUi : FluentBase
    {
        public FluentUi(string driverParams):
            this (new WebDriverFactory(driverParams).Get()) { }
        public FluentUi(DriverParams driverParams) :
           this(new WebDriverFactory(driverParams).Get())
        { }
        public FluentUi(WebDriverFactory webDriverFactory) :
           this(webDriverFactory.Get())
        { }
        public FluentUi(IWebDriver driver):
            this(driver, new TraceLogger()) { }
        public FluentUi(IWebDriver driver, ILogger logger):
          base(logger)
        {
            Driver = driver;
          
        }
        public IWebDriver Driver { get; }   

        public override T ChangeContext<T>(string application,ILogger logger)
        {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return Create<T>(null,logger);
        }
        public override T ChangeContext<T>(string application)
        {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return Create<T>(null,null);
        }

        public override T ChangeContext<T>(string type, string application)
        {
            var t = GetTypeByName(type);
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return Create<T>(t, null);
        }

        internal override T Create<T>(Type type,ILogger logger)
        {
            if(type==null)
            {
                type = typeof(T);
            }
            return logger == null ?
                (T)Activator.CreateInstance(type, new object[] { Driver }) :
                (T)Activator.CreateInstance(type, new object[] { Driver, logger });
        }
    }
}
