using GovProjectLibrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovProject
{
    public class GovOff
    {
        public static void GetPFDetails(IGovRules obj )
        {
            Console.WriteLine("PF Amount: " + obj.EmployeePF(obj.Salary));
        }

        public static void GetGratuityDetails(IGovRules obj, float serviceCompleted)
        {
            Console.WriteLine("Gratuity Amount: " + obj.GratuityAmount(serviceCompleted, obj.Salary));
        }

        public static void GetLeaveDetails(IGovRules obj)
        {
            Console.WriteLine(obj.LeaveDetails());
        }

        
    }
}
