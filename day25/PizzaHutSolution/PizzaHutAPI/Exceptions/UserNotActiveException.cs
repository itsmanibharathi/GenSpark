namespace PizzaHutAPI.Exceptions
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
            message = $"User is not active: {key}";
        }
        public override string Message => message;
    }
}
