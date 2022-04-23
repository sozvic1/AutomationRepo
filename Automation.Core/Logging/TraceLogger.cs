using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Logging
{
    public class TraceLogger : ILogger
    {
        void ILogger.Debug(string message)
        {
            Trace.TraceInformation(message);
        }

        void ILogger.Debug(string format, params object[] args)
        {
            Trace.TraceInformation(string.Format(format,args));
        }

        void ILogger.Debug(Exception exception, string message)
        {
            Trace.TraceInformation(message + " " + $"{exception}");
        }
    }
}
