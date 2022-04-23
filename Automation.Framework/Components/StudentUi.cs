﻿using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Framework.Ui.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Ui.Components
{
    public class StudentUi:FluentUi, IStudent
    {     
        private readonly IWebElement dataRow;
        private string firstName;
        private string lastName;
        private DateTime enrollementDate;
        public StudentUi(IWebDriver driver, IWebElement dataRow) : this(driver, new TraceLogger()) 
        {
            this.dataRow = dataRow;
            Build(dataRow);

        }

        public StudentUi(IWebDriver driver, ILogger logger) : base(driver, logger) { }
          

        // actions
        public object Delete()
        {
            throw new NotImplementedException();
        }

        public IStudentDetails Details()
        {
            dataRow.FindElement(By.XPath("//a[contains(@href,'/Student/Details')]")).Click();
            return new StudentDetailsUi(Driver);
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

        // data
        public DateTime EnrollementDate()
        {
            return enrollementDate;
        }

        public string FirstName()
        {
            return firstName;
        }

        public string LastName()
        {
            return lastName;
        }
        private void Build(IWebElement dataRow)
        {
            firstName = dataRow.FindElement(By.XPath("./td[1]")).Text.Trim();
            lastName = dataRow.FindElement(By.XPath("./td[2]")).Text.Trim();
            var dateString = dataRow.FindElement(By.XPath("./td[3]")).Text.Trim();

            DateTime.TryParse(dateString, out enrollementDate);
        }
    }
}
