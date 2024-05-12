using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary.Exceptions
{
    public class RequestSolutionIdNotFoundException : Exception
    {
        string message;
        public RequestSolutionIdNotFoundException()
        {
            message = "Request Solution ID not found";
        }
        public RequestSolutionIdNotFoundException(int requestSolutionId)
        {
            message = $"Request Solution ID {requestSolutionId} not found";
        }
        public override string Message => message;
    }
}
