using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary.Exceptions
{
    public class EmployeeIDNotFoundException : Exception
    {
        readonly string message;
        public EmployeeIDNotFoundException()
        {
            message = "Employee ID not found";
        }
        public EmployeeIDNotFoundException(int id)
        {
            this.message = $"Employee ID {id} not found";
        }
        public override string Message => message;
    }
}
