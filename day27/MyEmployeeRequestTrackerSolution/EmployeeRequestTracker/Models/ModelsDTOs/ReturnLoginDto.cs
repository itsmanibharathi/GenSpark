namespace EmployeeRequestTracker.Models.ModelsDTOs
{
    public class ReturnLoginDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public EmployeeRole employeeRole { get; set; }
        public string Token { get; set; }
        public ReturnLoginDto(User user)
        {
            EmployeeId = user.EmployeeId;
            Name = user.employee?.Name ?? string.Empty;
            employeeRole = user.employee.Role;
            Token = string.Empty;
        }
    }
}
