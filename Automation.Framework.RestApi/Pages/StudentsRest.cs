﻿using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Framework.RestApi.Components;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.RestApi.Pages
{
    public class StudentsRest : FluentRest,IStudents
    {
        private readonly IEnumerable<IStudent> students;
        public StudentsRest(HttpClient httpClient) : this (httpClient,new TraceLogger())
        {
        }

        public StudentsRest(HttpClient httpClient, ILogger logger) : this(httpClient, logger,string.Empty)
        {
        
        }
        private StudentsRest(HttpClient httpClient, ILogger logger,string name) : base(httpClient, logger)
        {
            students = Build(name);
        }
        public ICreateStudent Create()
        {
            throw new NotImplementedException();
        }

        public IStudents FindByName(string name)
        {
           return new StudentsRest(HttpClient, Logger, name);
        }

        public T Menu<T>(string menuName)
        {
            throw new NotImplementedException();
        }

        public IStudents Next()
        {
            throw new NotImplementedException();
        }

        public int Page()
        {
            throw new NotImplementedException();
        }

        public int Pages()
        {
            throw new NotImplementedException();
        }

        public IStudents Previous()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IStudent> Students()
        {
           return students;
        }
        private IEnumerable<IStudent> Build(string name)
        {
            var response = HttpClient.GetAsync("/api/Students").GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                return new IStudent[0];
            }
            var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var s = JToken.Parse(responseBody).Select(i => new StudentRestApi(HttpClient, i));
            
            const StringComparison COMPARE = StringComparison.OrdinalIgnoreCase; 

            return string.IsNullOrEmpty(name) 
                ? s 
                : s.Where(i => i.FirstName().Equals(name) ||
            i.LastName().Equals(name));
        }
    }
}
