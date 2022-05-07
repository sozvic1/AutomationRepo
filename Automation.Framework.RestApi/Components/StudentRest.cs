﻿using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Framework.RestApi.Pages;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.RestApi.Components
{
    public class StudentRest : FluentRest, IStudent
    {
        private readonly JToken dataRow;
        private int id;
        private string firstName;
        private string lastName;
        private DateTime enrollementDate;
        public StudentRest(HttpClient httpClient,JToken dataRow) :
            this(httpClient,new TraceLogger())
        {
            this.dataRow = dataRow;
            Build(dataRow);
        }

        public StudentRest(HttpClient httpClient, ILogger logger) : base(httpClient, logger)
        {
        }

        public object Delete()
        {
            throw new NotImplementedException();
        }

        public IStudentDetails Details()
        {
          return  new StudentDetailsRest(HttpClient, Logger, id);
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

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
        private void Build(JToken dataRow)
        {
            firstName = $"{dataRow["firstMidName"]}";
            lastName = $"{dataRow["lastName"]}";
            enrollementDate = DateTime.Parse($"{dataRow["enrollmentDate"]}");
            id = int.Parse($"{dataRow["id"]}");
        }
    }
}
