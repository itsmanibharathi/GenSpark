using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsStudy
{

    class Employee
    {
        public string Name { get; set; }
        public int EmployeeID { get; set; }

        public Employee(string name, int id)
        {
            Name = name;
            EmployeeID = id;
        }
    }

    class Department
    {
        public string Name { get; set; }
        readonly Dictionary<int, Employee> employees;
        public Department()
        {
            Name = "Default Department";
            employees = new Dictionary<int, Employee>();
        }
        public Department(string name)
        {
            Name = name;
            employees = new Dictionary<int, Employee>();
        }
        
        public Employee this[int employeeID]
        {
            get
            {
                if (employees.ContainsKey(employeeID))
                    return employees[employeeID];
                else
                    throw new KeyNotFoundException($"Employee with ID {employeeID} not found in the department.");
            }
            set
            {
                employees[employeeID] = value;
            }
        }
    }

    class MainClass
    {
        static void Main(string[] args)
        {

            Employee employee1 = new Employee("John Doe", 1001);
            Employee employee2 = new Employee("Jane Smith", 1002);
            Employee employee3 = new Employee("Bob Johnson", 1003);


            Department department1 = new Department("Dep1");
            Department department2 = new Department("Dep2");

            department1[employee1.EmployeeID] = employee1;
            department1[employee2.EmployeeID] = employee2;
            department2[employee3.EmployeeID] = employee3;

            Console.WriteLine($"Employees in {department1.Name}");
            Console.WriteLine(department1[1001].Name);
            Console.WriteLine(department1[1002].Name);

            Console.WriteLine($"\nEmployees in {department1.Name}");
            Console.WriteLine(department2[1003].Name);
        }
    }
}
