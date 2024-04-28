using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLib.Exceptions
{
    public class CustomerNotCreateCartException : Exception
    {
        string message;
        public CustomerNotCreateCartException()
        {
            message = "Customer not create cart";
        }
        public override string Message => message;
    }
}
