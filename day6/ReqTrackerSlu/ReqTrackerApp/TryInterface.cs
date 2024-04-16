using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReqTrackerModelLibrary;


namespace ReqTrackerApp
{
    internal class TryInterface
    {
        public void EmployeeClientVisit(IClientInteraction clientInteraction)
        {
            clientInteraction.Print();
        }

        public void EmployeeVisit(IEmployee employee)
        {
            employee.BuildEmployeeFromConsole();
            employee.PrintEmployeeDetails();
        }
    }
}
