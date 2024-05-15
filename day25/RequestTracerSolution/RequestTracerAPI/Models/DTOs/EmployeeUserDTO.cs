namespace RequestTracerAPI.Models.DTOs
{
    public class EmployeeUserDTO : Employee
    {
        public string Password { get; set; } = string.Empty;
    }
}
