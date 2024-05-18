namespace EmployeeRequestTracker.Models
{
    public enum EmployeeRole
    {
        Admin,
        Employee
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public EmployeeRole Role { get; set; }
        public DateTime DateOfJoining { get; set; } = DateTime.Now;
        public DateTime? DateOfLeaving { get; set; } 
        public User? user { get; set; }
    }
}
