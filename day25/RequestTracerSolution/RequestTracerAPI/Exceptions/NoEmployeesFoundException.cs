using System.Runtime.Serialization;

namespace RequestTracerAPI.Exceptions
{
    [Serializable]
    internal class NoEmployeesFoundException : Exception
    {
        string massage = "";
        public NoEmployeesFoundException()
        {
            massage = "No Employees Found";
        }
        public override string Message => massage;
    }
}