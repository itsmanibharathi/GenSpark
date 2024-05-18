namespace EmployeeRequestTracker.Models.ModelsDTOs
{
    public class ReturnEmployeeDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public EmployeeRole Role { get; set; }
        public DateTime DateOfJoining { get; set; }
        public DateTime? DateOfLeaving { get; set; }
    }
}
