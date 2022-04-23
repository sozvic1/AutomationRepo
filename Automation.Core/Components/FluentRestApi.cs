using Automation.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Components
{
    public class FluentRestApi : FluentBase
    {
        public FluentRestApi(HttpClient httpClient) : this(httpClient, new TraceLogger()) { }
        public FluentRestApi(HttpClient httpClient, ILogger logger):base(logger)
        {
            HttpClient = httpClient;
           
        }
        public HttpClient HttpClient  { get; }  

        public override T ChangeContext<T>(string application)
        {
            throw new NotImplementedException();
        }        

        public override T ChangeContext<T>(string application, ILogger logger)
        {
            throw new NotImplementedException();
        }
            

        internal override T Create<T>(ILogger logger)
        {
            throw new NotImplementedException();
        }
    }
}
