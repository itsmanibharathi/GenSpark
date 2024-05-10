using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary.Exceptions
{
    public class EmptyDBException : Exception
    {
        readonly string message;
        public EmptyDBException()
        {
            message = "The database is empty";
        }
        public EmptyDBException(string message)
        {
            this.message = message;
        }
        public override string Message => message;

    }
}
