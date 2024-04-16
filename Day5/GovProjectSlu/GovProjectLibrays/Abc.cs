using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovProjectLibrays
{
    public class Abc : Employee, IGovRules
    {
        public Abc()
        {
            CompanyName = "ABC";
        }
        public Abc(int id, string name, string department, string designation, double salary) : base(id, name, department, designation, salary, "XYZ")
        {
            CompanyName = "ABC";
        }

        public double EmployeePF(double basicSalary)
        {
            return (0.12 * basicSalary) + (0.0833 * basicSalary) + (0.0367 * basicSalary);
        }

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
        public string LeaveDetails()
        {
            return "Leave Details for ABC:\n1 day of Casual Leave per month\\r\\n12 days of Sick Leave per year\\r\\n10 days of Privilege Leave per year";
        }

    }
}
