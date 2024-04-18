using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class DuplicateDepartmentNameException : Exception
    {
        string msg;
        public DuplicateDepartmentNameException()
        {
            msg = "Department name already exists";
        }
        public override string Message => msg;
    }
    public class DepartmentNotFoundException : Exception
    {
        string msg;
        public DepartmentNotFoundException()
        {
            msg = "Department not found";
        }
        public override string Message => msg;
    }

}
