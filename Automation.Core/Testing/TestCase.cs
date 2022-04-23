using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Testing
{
    public abstract class TestCase
    {
        private int attempts;
        private ILogger logger;
        private IDictionary<string, object> testParams;

        protected TestCase()
        {
            testParams = new Dictionary<string, object>();
            attempts = 1;
            logger = new TraceLogger();
        }
        public IWebDriver Driver { get; private set; }
        public bool Actual { get; private set; }
        public abstract bool AutomationTest(IDictionary<string, object> testParams);
        public TestCase Execute()
        {
            
            for (int i = 0; i < attempts; i++)
            {
                Driver = Get();
                try
                {

                    Actual = AutomationTest(testParams);
                    if (Actual)
                    {
                        break;

                    }
                    logger.Debug($"[{GetType()?.FullName}] failed on attempt [{i+1}]");
                }
                catch (AssertInconclusiveException ex)
                {
                    logger.Debug(ex, ex.Message);
                    break;
                }
                catch (NotImplementedException ex)
                {

                    logger.Debug(ex, ex.Message);
                    break;
                }
                catch (Exception ex)
                {
                    logger.Debug(ex, ex.Message);
                }
                finally
                {
                    Driver?.Close();
                    Driver?.Dispose();
                    
                }
            }
          
            return this;
        }
        public TestCase WithTestParams(IDictionary<string, object> testParams)
        {
            this.testParams = testParams;
            return this;
        }
        public TestCase WithNumberOfAttempts(int numberOfAttempts)
        {
            attempts = numberOfAttempts;
            return this;
        }
        public TestCase WithLogger(ILogger logger)
        {
            this.logger = logger;
            return this;
        }
        private IWebDriver Get()
        { 
            const string Driver = "driver";

            var driverParams = new DriverParams { Binaries =".",Driver="CHROME"};
            if(testParams?.ContainsKey(Driver)==true)
            {
                driverParams.Driver = $"{testParams[Driver]}";
            }
            return new WebDriverFactory(driverParams).Get();
        }
    }
}
