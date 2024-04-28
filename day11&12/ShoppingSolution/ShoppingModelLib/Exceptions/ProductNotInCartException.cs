using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLib.Exceptions
{
    public class ProductNotInCartException : Exception
    {
        string message;
        public ProductNotInCartException()
        {
            message = "Product not in cart";
        }
        public override string Message => message;

    }
}
