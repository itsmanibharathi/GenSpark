
using RequestTrakerModelLibrary;
using RequestTrackerBLLibrary;
using System.Collections;
using System.Globalization;
using RequestTrackerDALLibrary;

namespace RequestTrackerApp
{
    internal class Program
    {
        void AddDepartment()
        {

            DepartmentBL departmentBL = new DepartmentBL();
            try
            {
              
                Department department = new Department() { Name = "IT" };
                int id = departmentBL.AddDepartment(department);
                Console.WriteLine(department);
                Console.WriteLine(departmentBL.ChangeDepartmentName("IT", "IT1"));


            }
            catch (DuplicateDepartmentNameException ddne)
            {
                Console.WriteLine(ddne.Message);
            }
        }


        static void Main(string[] args)
        {
            new Program().AddDepartment();
        }
    }
}
