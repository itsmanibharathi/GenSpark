using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLib.Exceptions
{
    public class EmptyDataBaseException : Exception
    {
        string message;
        public EmptyDataBaseException()
        {
            message = "Database is empty";
        }
        public override string Message => message;
    }
}
