using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Testing;
using Automation.Framework.Ui.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Testing.Cases
{
    internal class CreateStudents : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        {
            var firstName = $"{testParams["firstName"]}";
            var lastName = $"{testParams["lastName"]}";               
            var fluent = $"{testParams["fluent"]}";
            var students = $"{testParams["students"]}";

           return CreateFluentApi(fluent)
                .ChangeContext<IStudents>(students, $"{testParams["application"]}")
                .Create()
                .FirstName(firstName)
                .LastName(lastName)
                .EnrollementDate(DateTime.Now)
                .Create()
                .FindByName(firstName)
                .Students()
                .Any();
        }
    }
}
