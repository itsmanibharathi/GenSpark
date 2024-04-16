namespace GovProjectLibrays
{
    /// <summary>
    /// Represents an employee with basic information and methods related to government rules.
    /// </summary>
    public class Employee : IGovRules
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public double Salary { get; set; }
        public string CompanyName { get; set; }

        /// <summary>
        /// Default constructor for the Employee class.
        /// </summary>
        public Employee() { }

        /// <summary>
        /// Parameterized constructor for the Employee class.
        /// </summary>
        /// <param name="id">The employee ID.</param>
        /// <param name="name">The name of the employee.</param>
        /// <param name="department">The department in which the employee works.</param>
        /// <param name="designation">The designation of the employee.</param>
        /// <param name="salary">The salary of the employee.</param>
        /// <param name="companyName">The name of the company.</param>
        public Employee(int id, string name, string department, string designation, double salary, string companyName)
        {
            Id = id;
            Name = name;
            Department = department;
            Designation = designation;
            Salary = salary;
            CompanyName = companyName;
        }

        /// <summary>
        /// Static method to get employee ID from the console.
        /// </summary>
        /// <returns>The employee ID.</returns>
        static public int GetEmployeeIdFromConsole()
        {
            int id;
            Console.Write("Enter the Employee Id : ");
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.Write("Invalid Employee Id.\nPlease enter a valid Employee Id : ");
            }
            return id;
        }

        /// <summary>
        /// Static method to get a string input from the console.
        /// </summary>
        /// <param name="message">The message to display before input.</param>
        /// <returns>The input string.</returns>
        static public string GetStringFromConsole(string message)
        {
            Console.Write(message);
            string value = Console.ReadLine();
            while (string.IsNullOrEmpty(value))
            {
                Console.Write($"Input cannot be null.\n{message}");
                value = Console.ReadLine();
            }
            return value;
        }

        /// <summary>
        /// Static method to get a double input from the console.
        /// </summary>
        /// <param name="message">The message to display before input.</param>
        /// <returns>The input double value.</returns>
        static public double GetDoubleFromConsole(string message)
        {
            Console.Write(message);
            double value;
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.Write($"Enter a valid number: ");
            }
            return value;
        }

        /// <summary>
        /// Gets employee data from the console.
        /// </summary>
        public void GetDataFromConsole()
        {
            Name = GetStringFromConsole("Enter Name : ");
            Department = GetStringFromConsole("Enter Department : ");
            Designation = GetStringFromConsole("Enter Designation : ");
            Salary = GetDoubleFromConsole("Enter Salary : ");
        }

        /// <summary>
        /// Displays employee details.
        /// </summary>
        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Designation: {Designation}");
            Console.WriteLine($"Salary: {Salary}");
            Console.WriteLine($"Company Name: {CompanyName}");
        }

        /// <summary>
        /// Calculates the Employee Provident Fund (PF) contribution.
        /// </summary>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        /// <returns>The Employee PF amount.</returns>
        public virtual double EmployeePF(double basicSalary)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the Gratuity amount (to be overridden in derived classes).
        /// </summary>
        /// <param name="serviceCompleted">The years of service completed by the employee.</param>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        /// <returns>The Gratuity amount.</returns>
        public virtual double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves the leave details (to be overridden in derived classes).
        /// </summary>
        /// <returns>A string containing leave details.</returns>
        public virtual string LeaveDetails()
        {
            throw new NotImplementedException();
        }
    }
}
