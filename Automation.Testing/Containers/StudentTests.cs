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
        [DataRow("{'driver':'CHROME','keyword':'Alexander','application':'https://gravitymvctestapplication.azurewebsites.net/Student'}")]
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
        [TestMethod]
        public void TempTest()
        {
            var studentRest = new FluentRestApi(new HttpClient()).ChangeContext<StudentsRest>("https://gravitymvctestapplication.azurewebsites.net").Students();
            //var studentsRst = new StudentsRest(new System.Net.Http.HttpClient()).Students();
            var s = studentRest.First().FirstName();
        }
    }
}
