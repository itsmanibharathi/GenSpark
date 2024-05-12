using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary.Exceptions
{
    public class RequestIdNotFoundException : Exception
    {
        string message;
        public RequestIdNotFoundException()
        {
            message = "Request ID not found";
        }
        public RequestIdNotFoundException(int requestId)
        {
            message = $"Request ID {requestId} not found";
        }
        public override string Message => message;
    }
}
