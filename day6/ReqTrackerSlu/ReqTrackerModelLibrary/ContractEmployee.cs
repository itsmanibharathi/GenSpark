using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqTrackerModelLibrary
{
    public class ContractEmployee : Employee
    {
        public double WagesPerDay { get; set; }
        public ContractEmployee()
        {
            EmployeeType = "Contract";
            Console.WriteLine("Contract employee constructor");
        }
        public ContractEmployee(int id, string name, DateTime dateOfBirth, double wagesPerDay) : base(id, name, dateOfBirth, "Permanent")
        { 
            WagesPerDay = wagesPerDay;
            Salary = CalculateMonthlySalary();
        }
        public override void BuildEmployeeFromConsole()
        {
            base.BuildEmployeeFromConsole();
            WagesPerDay = GetEmployeeWagesPerDayFromConsole();
            Salary = CalculateMonthlySalary();
        }
        public override void PrintEmployeeDetails()
        {
            base.PrintEmployeeDetails();
            Console.WriteLine("Employee Wages per day : " + WagesPerDay);
            Console.WriteLine("Employee Salary : " + Salary);

        }

        private double GetEmployeeWagesPerDayFromConsole()
        {
            double wagesPerDay;
            Console.Write("Enter the Wages per day : ");
            while (!double.TryParse(Console.ReadLine(), out wagesPerDay) || wagesPerDay <= 0)
            {
                Console.Write("Invalid Wages per day.\nPlease enter a valid Wages per day : ");
            }
            return wagesPerDay;
        }
        public double CalculateMonthlySalary()
        {
            return WagesPerDay * 30;
        }
    }
}
