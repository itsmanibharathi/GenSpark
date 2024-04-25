using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLib.Exceptions
{
    public class NoProductWithGiveIdException : Exception
    {
        string message;
        public NoProductWithGiveIdException()
        {
            message = "No Product with the given Id";
        }
        public override string Message => message;
    }
}
