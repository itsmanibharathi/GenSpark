using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary.Exceptions
{
    public class DatabaseEmptyException : Exception
    {
        string message;
        public DatabaseEmptyException()
        {
            message = "Database is empty";
        }
        public DatabaseEmptyException(string databaseName)
        {
            message = databaseName + " Database is empty";
        }
        public override string Message => message;
    }
}
