using System.Runtime.Serialization;

namespace EmployeeRequestTracker.Exceptions
{
    public class NoEmployeeInThisID : Exception
    {
        string message;

        public NoEmployeeInThisID()
        {
            message = "No User in this ID";
        }

        public NoEmployeeInThisID(int key)
        {
            message = $"No User in this ID: {key}";
        }
        public override string Message => message;
    }
}