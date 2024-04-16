using ReqTrackerModelLibrary;
using System.Security.Cryptography;
using System.Xml.Linq;
namespace ReqTrackerApp
{
    internal class Program
    {

        Employee[] employees;
        public Program()
        {
            employees = new Employee[10];
        }
        public int i = 0;
        void PrintMenu()
        {
            Console.WriteLine("1. Add one Employee");
            Console.WriteLine("2. Add Multiple Employees");
            Console.WriteLine("3. Print Employees");
            Console.WriteLine("4. Search Employee by ID");
            Console.WriteLine("5. Update Employee by ID");
            Console.WriteLine("6. Delete Employee by ID");
            Console.WriteLine("0. Exit");
        }
        public void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                int tid;
                Console.Write("Please select an option : ");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 5)
                    Console.Write("Invalid entry.\nPlease select an option : ");
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddOneEmployee();
                        break;
                    case 2:
                        AddMultipleEmployees();
                        break;
                    case 3:
                        PrintAllEmployees();
                        break;
                    case 4:
                        SearchAndPrintEmployee();
                        break;
                    case 5:
                        UpdateOneEmployee();
                        break;
                    case 6:
                        DeleteOneEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        void AddMultipleEmployees()
        { 
            int count = 0;
            Console.Write("Enter the number of employees to be added : ");
            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            {
                Console.Write("Invalid entry.\nPlease enter a valid number of employees : ");
            }
            for (int i = 0; i < count; i++)
            {
                AddOneEmployee();
            }
        }


        void AddOneEmployee()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            employees[i] = CreateEmployee(i++);
        }
        void PrintAllEmployees()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                    PrintEmployee(employees[i]);
                else
                    Console.WriteLine($"The Employee details is not available in {i} record");
            }
        }
        Employee CreateEmployee(int id)
        {
            Employee employee =null;
            Console.Write("Enter the type of Employee (Permanent/Contract) or [p/c] : ");
            while (true)
            {
                string type = Console.ReadLine();
                if (type.ToLower() == "permanent" || type.ToLower() == "p")
                {
                    employee = new PermanentEmployee();
                    break;
                }
                else if (type.ToLower() == "contract" || type.ToLower() =="c")
                {
                    employee = new ContractEmployee();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Employee type.\nPlease enter a valid Employee type : ");
                }
            }
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }
        void SearchAndPrintEmployee()
        {
            int id = Employee.GetEloyeeIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                return;
            }
            PrintEmployee(employee);
        }
        Employee SearchEmployeeById(int id)
        {
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {

                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            if (employee == null)
            {
                Console.WriteLine($"No such Employee is present in Employee :{id} ");
            }
            return employee;
        }
        void UpdateEmployeeByID(int id)
        {
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                return;
            }
            Console.WriteLine("The Existing Name is : " + employee.Name);
            employee.Name = Employee.GetEmployeeNameFromConsole();
            Console.WriteLine("Employee details updated successfully");
        }

        void UpdateOneEmployee()
        {
            int id = Employee.GetEloyeeIdFromConsole();
            UpdateEmployeeByID(id);

        }
        void DeleteOneEmployee()
        {
            int id = Employee.GetEloyeeIdFromConsole();
            DeleteOneEmployeeByID(id);
        }
        void DeleteOneEmployeeByID(int id)
        {
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    employees[i] = null;
                    Console.WriteLine("Employee deleted successfully");
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            //Program program = new Program();
            //program.EmployeeInteraction();

            //ContractEmployee contractEmployee = new ContractEmployee();
            //contractEmployee.BuildEmployeeFromConsole();
            //contractEmployee.PrintEmployeeDetails();


            //ContractEmployee contractEmployee1 = new ContractEmployee(101, "John", new DateTime(1990, 10, 10), 1000, 100);

            //contractEmployee1.PrintEmployeeDetails();


            //PermanentEmployee permanentEmployee = new PermanentEmployee();

            //permanentEmployee.BuildEmployeeFromConsole();


            Employee e = new Employee();
            TryInterface i = new TryInterface();
            i.EmployeeClientVisit(e);
            i.EmployeeVisit(e);
            
        }
    }
}
