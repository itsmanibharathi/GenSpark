namespace EmployeeRequestTracker.Models.ModelsDTOs
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public EmployeeRole Role { get; set; } = EmployeeRole.Employee;
    }
}
