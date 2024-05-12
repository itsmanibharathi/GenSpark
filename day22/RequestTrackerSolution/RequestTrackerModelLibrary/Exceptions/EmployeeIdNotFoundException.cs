using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary.Exceptions
{
    public class EmployeeIdNotFoundException : Exception
    {
        string message;
        public EmployeeIdNotFoundException()
        {
            message = "Employee ID not found";
        }
        public EmployeeIdNotFoundException(int employeeId)
        {
            message = $"Employee ID  {employeeId} not found";
        }
        public override string Message => message;
    }
}
