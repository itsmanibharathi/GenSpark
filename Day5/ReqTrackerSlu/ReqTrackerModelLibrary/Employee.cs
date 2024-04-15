namespace ReqTrackerModelLibrary
{
    public class Employee
    {
        int age;
        DateTime dob;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
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
        public double Salary { get; set; }

        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0.0;
            DateOfBirth = DateTime.MinValue;
        }
        public Employee(int id, string name, DateTime dateOfBirth, double salary)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Salary = salary;
        }

        public void BuildEmployeeFromConsole()
        {
            Console.Write("Please enter the Name : ");
            Name = Console.ReadLine();
            while (String.IsNullOrEmpty(Name)) {
                Console.Write("Name cannot be empty.\nPlease enter the Name : ");
                Name = Console.ReadLine() ;
            }
            Console.Write("Please enter the Date of birth : ");
            while (!DateTime.TryParse(Console.ReadLine(), out dob ))
            {
                Console.Write("Invalid Date of birth.\nPlease enter the Date of birth : ");
            }
            DateOfBirth = dob;
            Console.Write("Please enter the Basic Salary :");
            while (true)
            {
                double salary;
                if (double.TryParse(Console.ReadLine(), out salary) && salary > 0)
                {
                    if (salary > 0)
                    {
                        Salary = salary;
                        break;
                    }
                    else
                    Console.WriteLine("Salary should be greater than 0");
                }
                else 
                    Console.Write("Invalid Salary.\nPlease enter a valid salary:");
            }
        }

        public void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee Id : " + Id);
            Console.WriteLine("Employee Name " + Name);
            Console.WriteLine("Date of birth : " + DateOfBirth);
            Console.WriteLine("Employee Age : " + Age);
            Console.WriteLine("Employee Salary : Rs." + Salary);
        }
    }
}
