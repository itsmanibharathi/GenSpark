using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLib.Exceptions
{
    public class EmptyDataBase : Exception
    {
        public EmptyDataBase(string message) : base(message)
        {
            message = "Database is empty";
        }
        public override string Message => base.Message;
    }
}
