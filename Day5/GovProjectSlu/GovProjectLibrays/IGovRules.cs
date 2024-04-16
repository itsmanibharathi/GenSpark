using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovProjectLibrays
{
    public interface IGovRules
    {
        public double Salary { get; set; }
        public double EmployeePF(double basicSalary);
        public double GratuityAmount(float serviceCompleted, double basicSalary);
        string LeaveDetails();
    }
}
