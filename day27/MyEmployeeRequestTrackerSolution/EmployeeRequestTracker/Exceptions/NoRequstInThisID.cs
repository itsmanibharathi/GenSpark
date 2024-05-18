using System.Runtime.Serialization;

namespace EmployeeRequestTracker.Exceptions
{
    public class NoRequstInThisID : Exception
    {
        string message;

        public NoRequstInThisID()
        {
            message = "No Pizza in this ID";
        }

        public NoRequstInThisID(int key)
        {
            message = $"No Pizza in this ID: {key}";
        }
        public override string Message => message;
    }
}