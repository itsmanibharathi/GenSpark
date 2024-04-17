using ReqTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqTrackerApp
{
    internal class TryOverloding
    {
        public static void Main()
        {
            Employee e1 = new Employee(101,"Mani",DateTime.MinValue,2000);
            Employee e2 = new Employee(101, "Mani", DateTime.MinValue, 2000);
            if(e1 == e2)
                Console.WriteLine("Both Employees are same");
            else
                Console.WriteLine("Both Employees are different");

            if(e1.Equals(e2))
                Console.WriteLine("Both Employees are same");
            else
                Console.WriteLine("Both Employees are different");

            Console.WriteLine(e1);
        }
    }
}
