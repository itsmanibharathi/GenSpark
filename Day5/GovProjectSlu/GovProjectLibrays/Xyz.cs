using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovProjectLibrays
{
    public class Xyz : Employee, IGovRules
    {
        public Xyz()
        {
            CompanyName = "XYZ";
        }
        public Xyz(int id, string name, string department, string designation, double salary) : base(id, name, department, designation, salary, "XYZ")
        {
            CompanyName = "XYZ";
        }

        public double EmployeePF(double basicSalary)
        {
            return (0.12 * basicSalary) + (0.12 * basicSalary);
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }
        public string LeaveDetails()
        {
            return "Leave Details for ABC:\n2 day of Casual Leave per month\r\n5 days of Sick Leave per year\r\n5 days of Previlage Leave per year";

        }

    }
}
