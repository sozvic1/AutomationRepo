using Automation.Core.Components;
using Automation.Framework.RestApi.Pages;
using Automation.Testing.Cases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Testing.Containers
{
    [TestClass]
    public class StudentTests
    {
        [DataTestMethod]
        //[DataRow("" +
        //    "{" +
        //    "'driver':'CHROME'," +
        //    "'keyword':" +
        //    "'Alexander'," +
        //    "'application':'https://gravitymvctestapplication.azurewebsites.net/Student'," +
        //    "'fluent':'Automation.Core.Components.FluentUi'," +
        //    "'students':'Automation.Framework.Ui.Pages.StudentsUi'" +
        //    "}")]
        [DataRow("" +
           "{" +
           "'driver':'HTTP'," +
           "'keyword':" +
           "'Alexander'," +
           "'application':'https://gravitymvctestapplication.azurewebsites.net'," +
           "'fluent':'Automation.Core.Components.FluentRest'," +
           "'students':'Automation.Framework.RstApi.Pages.StudentsRest'" +
           "}")]
        public void SearchStudentUiTest(string testParams)
        {
            var parametrs =JsonConvert.DeserializeObject<Dictionary<string,object>>(testParams);
            var actual = new SearchStudents().WithTestParams(parametrs).Execute().Actual;
           
            Assert.IsTrue( actual);
        }
      

        [DataTestMethod]
        [DataRow("{'driver':'CHROME','firstName':'csahrp','lastName':'student','keyword':'Alexander','application':'https://gravitymvctestapplication.azurewebsites.net/Student'}")]
        public void CreateStudentUiTest(string testParams)
        {
            var parametrs = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);
            var actual = new CreateStudents().WithTestParams(parametrs).Execute().Actual;

            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow("{'driver':'CHROME','keyword':'Alexander','application':'https://gravitymvctestapplication.azurewebsites.net/Student'}")]
        public void StudentDetailsTest(string testParams)
        {
            // generate  test-parameters
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            // execute with parameters
            var actual = new StudentDetails().WithTestParams(parameters).Execute().Actual;

            // assert results
            Assert.IsTrue(actual);
        }
     
    }
}
