using Automation.Api.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Api.Components
{
    public interface IStudent :IPersonalDetails,IDetails<IStudentDetails>,IDelete<object>,IEdit<object>
    {       
        
    }
}
