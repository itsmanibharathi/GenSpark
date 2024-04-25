using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLib.Exceptions
{
    public class NoCustomerWithGiveIdException : Exception
    {
        public NoCustomerWithGiveIdException(string message) : base(message)
        {
            message = "No Customer with the given Id";
        }
        public override string Message => base.Message;
    }
}
