using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary.Exceptions
{
    public class LoginFaliException : Exception
    {
        readonly string message;
        public LoginFaliException()
        {
            message = "Login Failed";
        }
        public override string Message => message;
    }
}
