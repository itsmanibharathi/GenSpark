using GovProjectLibrays;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace GovProject
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
            Console.WriteLine("\n1. Add one Employee");
            Console.WriteLine("2. Add Multiple Employees");
            Console.WriteLine("3. Print Employees");
            Console.WriteLine("4. Search Employee by ID");
            Console.WriteLine("5. Calculate the pf amount by ID");
            Console.WriteLine("6. Get Gratuity Details by ID");
            Console.WriteLine("7. Get Leave Details");
            Console.WriteLine("0. Exit");
        }
        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                int tid;
                Console.Write("Please select an option : ");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 7)
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
                        CalPF();
                        break;
                    case 6:
                        GetGratuityDetails();
                        break;
                    case 7:
                        GovOff.GetLeaveDetails(GetUserCompanyFromConsole());
                        break;
                    default:

                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }

        private void GetGratuityDetails()
        {

            int tid = Employee.GetEloyeeIdFromConsole();
            int serviceCompleted;
            while (!int.TryParse(Console.ReadLine(), out serviceCompleted) || serviceCompleted < 0)
            {
                Console.Write("Invalid entry.\nPlease enter a valid number of employees : ");
            }
            GovOff.GetGratuityDetails(SearchEmployeeById(tid), serviceCompleted);
        }

        private void CalPF()
        {
            int tid = Employee.GetEloyeeIdFromConsole();
            GovOff.GetPFDetails(SearchEmployeeById(tid));
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

        static Employee GetUserCompanyFromConsole()
        {
            Console.Write("Enter the Company Name (ABC/XYZ): ");
            string companyName = Console.ReadLine();
            while (true)
            {
                if (companyName.ToUpper() == "ABC")
                {
                    return new Abc();
                }
                else if (companyName.ToUpper() == "XYZ")
                {
                    return new Xyz();
                }
                else
                {
                    Console.Write("Invalid Company Name.\nPlease enter either ABC or XYZ: ");
                    companyName = Console.ReadLine();
                }
            }
        }
        Employee CreateEmployee(int id)
        {
            Employee employee = GetUserCompanyFromConsole();
            employee.Id = 101 + id;
            employee.GetDataFromConsole();
            return employee;
        }

        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.DisplayEmployeeDetails();
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
            employee.Name = Employee.getStringFromConsole("Enter The Name");
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
            Program program = new Program();
            program.EmployeeInteraction();
        }
    }
}




