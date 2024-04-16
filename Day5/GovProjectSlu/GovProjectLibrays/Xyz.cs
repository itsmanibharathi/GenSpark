using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovProjectLibrays
{
    /// <summary>
    /// Represents an employee working in the XYZ company.
    /// </summary>
    public class Xyz : Employee, IGovRules
    {
        /// <summary>
        /// Default constructor for the Xyz class.
        /// </summary>
        public Xyz()
        {
            CompanyName = "XYZ";
        }

        /// <summary>
        /// Parameterized constructor for the Xyz class.
        /// </summary>
        /// <param name="id">The employee ID.</param>
        /// <param name="name">The name of the employee.</param>
        /// <param name="department">The department in which the employee works.</param>
        /// <param name="designation">The designation of the employee.</param>
        /// <param name="salary">The salary of the employee.</param>
        public Xyz(int id, string name, string department, string designation, double salary) : base(id, name, department, designation, salary, "XYZ")
        {
            CompanyName = "XYZ";
        }

        /// <summary>
        /// Calculates the Employee Provident Fund (PF) contribution.
        /// </summary>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        /// <returns>The Employee PF amount.</returns>
        public double EmployeePF(double basicSalary)
        {
            return (0.12 * basicSalary) + (0.12 * basicSalary);
        }

        /// <summary>
        /// Calculates the Gratuity amount based on the completed years of service.
        /// </summary>
        /// <param name="serviceCompleted">The years of service completed by the employee.</param>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        /// <returns>The Gratuity amount.</returns>
        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }

        /// <summary>
        /// Retrieves the leave details for employees of the XYZ company.
        /// </summary>
        /// <returns>A string containing leave details.</returns>
        public string LeaveDetails()
        {
            return "Leave Details for XYZ:\n2 days of Casual Leave per month\n5 days of Sick Leave per year\n5 days of Privilege Leave per year";
        }
    }
}
