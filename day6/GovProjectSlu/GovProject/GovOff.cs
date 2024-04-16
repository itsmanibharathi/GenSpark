using GovProjectLibrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovProject
{
    /// <summary>
    /// Represents a government office that provides various employee-related details.
    /// </summary>
    public class GovOff
    {
        /// <summary>
        /// Retrieves the Employee Provident Fund (PF) details.
        /// </summary>
        /// <param name="obj">An object implementing the IGovRules interface.</param>
        public static void GetPFDetails(IGovRules obj)
        {
            Console.WriteLine("PF Amount: " + obj.EmployeePF(obj.Salary));
        }

        /// <summary>
        /// Retrieves the Gratuity details based on the completed years of service.
        /// </summary>
        /// <param name="obj">An object implementing the IGovRules interface.</param>
        /// <param name="serviceCompleted">The years of service completed by the employee.</param>
        public static void GetGratuityDetails(IGovRules obj, float serviceCompleted)
        {
            Console.WriteLine("Gratuity Amount: " + obj.GratuityAmount(serviceCompleted, obj.Salary));
        }

        /// <summary>
        /// Retrieves the leave details for employees.
        /// </summary>
        /// <param name="obj">An object implementing the IGovRules interface.</param>
        public static void GetLeaveDetails(IGovRules obj)
        {
            Console.WriteLine(obj.LeaveDetails());
        }
    }
}
