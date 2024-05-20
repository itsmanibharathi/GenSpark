using System.Runtime.Serialization;

namespace PizzaHutAPI.Exceptions
{
    public class NoUserInThisID : Exception
    {
        string message;

        public NoUserInThisID()
        {
            message = "No User in this ID";
        }

        public NoUserInThisID(int key)
        {
            message = $"No User in this ID: {key}";
        }
        public override string Message => message;
    }
}