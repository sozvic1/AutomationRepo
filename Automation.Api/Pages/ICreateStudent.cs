using Automation.Api.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Api.Pages
{
    public interface ICreateStudent:IPersonalDetails,ICreate<IStudents>,IBack<IStudents>
    {
        ICreateStudent FirstName(string firstName);
        ICreateStudent LastName(string lastName);
        ICreateStudent EnrollementDate(DateTime enrollment);
    }
}
