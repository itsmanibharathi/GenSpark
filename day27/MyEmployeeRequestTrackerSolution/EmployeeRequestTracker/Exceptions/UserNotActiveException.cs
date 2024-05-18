namespace EmployeeRequestTracker.Exceptions
{
    public class UserNotActiveException : Exception
    {
        string message;

        public UserNotActiveException()
        {
            message = "User is not active";
        }

        public UserNotActiveException(int key)
        {
            message = $"User: {key} is not active";
        }
        public override string Message => message;
    }
}
