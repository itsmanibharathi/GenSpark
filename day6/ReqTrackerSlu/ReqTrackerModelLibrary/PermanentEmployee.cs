using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqTrackerModelLibrary
{
    public class PermanentEmployee : Employee
    {
        public PermanentEmployee()
        {
            EmployeeType = "Permanent";
            Console.WriteLine("Permanent employee constructor");
        }

        public PermanentEmployee(int id, string name, DateTime dateOfBirth, double salary) : base(id, name, dateOfBirth, "Permanent")
        {
            EmployeeType = "Permanent";
            Salary = salary;
            Console.WriteLine("Permanent Employee class prameterized constructor");
        }

        public override void BuildEmployeeFromConsole()
        {
            Name = GetEmployeeNameFromConsole();
            DateOfBirth = GetEmployeeDOBFromConsole();
            Salary = GetEmployeeSalaryFromConsole();
        }

        public override void PrintEmployeeDetails()
        {
            base.PrintEmployeeDetails();
            Console.WriteLine("Employee Salary : " + Salary);
        }

    }
}
