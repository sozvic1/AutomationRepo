using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.RestApi.Pages
{
    public class StudentDetailsRest : FluentRest, IStudentDetails
    {
        private string firstMidName;
        public StudentDetailsRest(HttpClient httpClient) : this(httpClient, new TraceLogger())
        {
        }

        public StudentDetailsRest(HttpClient httpClient, ILogger logger) : this(httpClient, logger,0)
        {
        }
        public StudentDetailsRest(HttpClient httpClient, ILogger logger,int id) : base(httpClient, logger)
        {
            Build(id);
        }
        public DateTime EnrollementDate()
        {
            throw new NotImplementedException();
        }

        public IEnrollment[] Enrollments()
        {
            throw new NotImplementedException();
        }

        public string FirstName() => firstMidName;
      

        public string LastName()
        {
            throw new NotImplementedException();
        }
        private void Build(int id)
        {
            var response = HttpClient.GetAsync($"/api/Students/{id}").GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
           
            var token = JToken.Parse(responseBody);
            firstMidName =$"{token["firstMidName"]}";

       
        }
    }
}
