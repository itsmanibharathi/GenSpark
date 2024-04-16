namespace GovProjectLibrays
{
    public class Employee : IGovRules
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public double Salary { get; set; }
        public string CompanyName { get; set; }

        public Employee() { }  
        
        public Employee(int id, string name, string department, string designation, double salary, string companyName)
        {
            Id = id;
            Name = name;
            Department = department;
            Designation = designation;
            Salary = salary;
            CompanyName = companyName;
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

        static public string getStringFromConsole(string message)
        {
            Console.Write(message);
            string value = Console.ReadLine();
            while (string.IsNullOrEmpty(value))
            {
                Console.Write($"Input Not be a null\n{message}");
                value = Console.ReadLine();
            }
            return value;
        }
        static public double getDoubleFromConsole(string message)
        {
            Console.Write(message);
            double value;
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.Write($"Enter valid number: ");
            }
            return value;
        }

        public void GetDataFromConsole()
        {
            Name = getStringFromConsole("Enter Name : ");
            Department = getStringFromConsole("Enter Department : ");
            Designation = getStringFromConsole("Enter Designation : ");
            Salary = getDoubleFromConsole("Enter Salary : ");
            
        }
        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Designation: {Designation}");
            Console.WriteLine($"Salary: {Salary}");
            Console.WriteLine($"Company Name: {CompanyName}");
        }
        public virtual double EmployeePF(double basicSalary)
        {
            throw new NotImplementedException();
        }

        public virtual double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            throw new NotImplementedException();
        }

        public virtual string LeaveDetails()
        {
            throw new NotImplementedException();
        }
    }
}
