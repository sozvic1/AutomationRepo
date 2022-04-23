using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Api.Components
{
    public interface IPersonalDetails
    {
        string FirstName();
        string LastName();
        DateTime EnrollementDate();
    }
}
