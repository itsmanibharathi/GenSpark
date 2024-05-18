using System.Runtime.Serialization;

namespace EmployeeRequestTracker.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        string message;

        public AlreadyExistsException()
        {
            message = "Already Exists";
        }
        public override string Message => message;


    }
}