namespace PizzaHutAPI.Exceptions
{
    public class FailToLoginException: Exception
    {
        string message;

        public FailToLoginException()
        {
            message = "Fail to login";
        }
        public override string Message => message;
    }
}
