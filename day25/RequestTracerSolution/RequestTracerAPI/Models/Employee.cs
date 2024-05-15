namespace RequestTracerAPI.Models
{
    public enum EmployeeRole
    {
        Admin,
        Employee
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public EmployeeRole Role { get; set; }
    }
}
