using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Testing;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Automation.Framework.Ui.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Testing.Cases
{
    public class SearchStudents : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        {
            var keyword =$"{testParams["keyword"]}";

          

            return new FluentUi(Driver)
                .ChangeContext<StudentsUi>($"{testParams["application"]}")
                .FindByName(keyword)
                .Students()
                .All(i=>i.FirstName().Equals(keyword) ||i.LastName().Equals(keyword));
          
          
        }
    }
}
