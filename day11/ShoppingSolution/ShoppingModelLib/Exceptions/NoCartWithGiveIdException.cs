using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLib.Exceptions
{
    public class NoCartWithGiveIdException : Exception
    {
        public NoCartWithGiveIdException(string message) : base(message)
        {
            message = "No Cart with the given Id";
        }
        public override string Message => base.Message;
    }
}
