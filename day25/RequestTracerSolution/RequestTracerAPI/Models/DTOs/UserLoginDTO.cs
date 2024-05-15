namespace RequestTracerAPI.Models.DTOs
{
    public class UserLoginDTO
    {
        public int EmployeeId { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
