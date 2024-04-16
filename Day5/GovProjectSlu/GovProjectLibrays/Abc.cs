using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovProjectLibrays
{
    /// <summary>
    /// Represents an employee working in the ABC company.
    /// </summary>
    public class Abc : Employee, IGovRules
    {
        /// <summary>
        /// Default constructor for the Abc class.
        /// </summary>
        public Abc()
        {
            CompanyName = "ABC";
        }

        /// <summary>
        /// Parameterized constructor for the Abc class.
        /// </summary>
        /// <param name="id">The employee ID.</param>
        /// <param name="name">The name of the employee.</param>
        /// <param name="department">The department in which the employee works.</param>
        /// <param name="designation">The designation of the employee.</param>
        /// <param name="salary">The salary of the employee.</param>
        public Abc(int id, string name, string department, string designation, double salary) : base(id, name, department, designation, salary, "XYZ")
        {
            CompanyName = "ABC";
        }

        /// <summary>
        /// Calculates the Employee Provident Fund (PF) contribution.
        /// </summary>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        /// <returns>The Employee PF amount.</returns>
        public double EmployeePF(double basicSalary)
        {
            return (0.12 * basicSalary) + (0.0833 * basicSalary) + (0.0367 * basicSalary);
        }

        /// <summary>
        /// Calculates the Gratuity amount based on the completed years of service.
        /// </summary>
        /// <param name="serviceCompleted">The years of service completed by the employee.</param>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        /// <returns>The Gratuity amount.</returns>
        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            if (serviceCompleted > 20)
            {
                return 3 * basicSalary;
            }
            else if (serviceCompleted > 10)
            {
                return 2 * basicSalary;
            }
            else if (serviceCompleted > 5)
            {
                return basicSalary;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Retrieves the leave details for employees of the ABC company.
        /// </summary>
        /// <returns>A string containing leave details.</returns>
        public string LeaveDetails()
        {
            return "Leave Details for ABC:\n1 day of Casual Leave per month\n12 days of Sick Leave per year\n10 days of Privilege Leave per year";
        }
    }
}
