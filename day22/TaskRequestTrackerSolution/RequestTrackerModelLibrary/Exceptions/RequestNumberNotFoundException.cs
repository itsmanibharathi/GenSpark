using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary.Exceptions
{
    public class RequestNumberNotFoundException : Exception
    {
        readonly string message;
        public RequestNumberNotFoundException()
        {
            message = "Request Number not found";
        }
        public RequestNumberNotFoundException(int id)
        {
            this.message = $"Request Number {id} not found";
        }
        public override string Message => message;
    }
}
