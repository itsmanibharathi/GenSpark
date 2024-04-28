using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLib.Exceptions
{
    public class NoCartWithGiveIdException : Exception
    {
        string message;
        public NoCartWithGiveIdException()  
        {
            message = "No Cart with the given Id";
        }
        public override string Message => message;
    }
}
