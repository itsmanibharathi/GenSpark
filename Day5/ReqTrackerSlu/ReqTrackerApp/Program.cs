using ReqTrackerModelLibrary;
namespace ReqTrackerApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.BuildEmployeeFromConsole();
            emp.PrintEmployeeDetails();
        }
    }
}
