using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqTrackerModelLibrary
{
    public interface IClientInteraction
    {
        public void Print();

    }
    public interface IEmployee
    {
        public void BuildEmployeeFromConsole();
        public void PrintEmployeeDetails();
    }
}
