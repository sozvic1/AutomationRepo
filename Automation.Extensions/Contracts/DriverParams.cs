using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Extensions.Contracts
{
    [DataContract]
    public class DriverParams
    {
        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public string Driver { get; set; }

        [DataMember]
        public string Binaries { get; set; }
    }
}
