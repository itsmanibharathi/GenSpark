using System.Globalization;

namespace ReqTrackerModelLibrary
{
    public class Employee : IClientInteraction , IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        int age;
        DateTime dob;
        public int Age
        {
            get
            {
                return age;
            }
        }
        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }
        }
        public string EmployeeType { get; set; }
        public double Salary { get; set; }

        public Employee()
        {
            Console.WriteLine("Employee default Constructor");
            Id = 0;
            Name = string.Empty;
            EmployeeType = string.Empty;
            DateOfBirth = DateTime.MinValue;
        }
        public Employee(int id, string name, DateTime dateOfBirth, string employeeType)
        {
            Console.WriteLine("Employee Parameterized Constructor");
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            EmployeeType = employeeType;
        }

        static public int GetEloyeeIdFromConsole()
        {
            int id;
            Console.Write("Enter the Employee Id : ");
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.Write("Invalid Employee Id.\nPlease enter a valid Employee Id : ");
            }
            return id;
        }
        static public string GetEmployeeNameFromConsole()
        {
            Console.Write("Enter the Name : ");
            string name = Console.ReadLine();
            while (String.IsNullOrEmpty(name))
            {
                Console.Write("Name cannot be empty.\nPlease enter the Name : ");
                name = Console.ReadLine();
            }
            return name;
        }
        static public DateTime GetEmployeeDOBFromConsole()
        {
            DateTime dob;
            Console.Write("Enter the Date of birth : ");
            while (!DateTime.TryParse(Console.ReadLine(), out dob))
            {
                Console.Write("Invalid Date of birth.\nPlease enter the Date of birth : ");
            }
            return dob;
        }
        static public double GetEmployeeSalaryFromConsole()
        {
            double salary;
            Console.Write("Enter the Basic Salary :");
            while (!double.TryParse(Console.ReadLine(), out salary) || salary <= 0)
            {
                Console.Write("Invalid Salary.\nPlease enter a valid salary:");
            }
            return salary;
        }

        public virtual void BuildEmployeeFromConsole()
        {
            Name = GetEmployeeNameFromConsole();
            DateOfBirth = GetEmployeeDOBFromConsole();
        }

        public virtual void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee Id : " + Id);
            Console.WriteLine("Employee Name " + Name);
            Console.WriteLine("Date of birth : " + DateOfBirth);
            Console.WriteLine("Employee Age : " + Age);
            Console.WriteLine("Employee Type : " + EmployeeType);

        }

        public void Print()
        {
            Console.WriteLine("Print from InterfaceTest");
        }
    }
}
