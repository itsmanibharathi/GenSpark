namespace EmployeeRequestTracker.Models.ModelsDTOs
{
    public class RegisterLoginDto
    {
        public int EmployeeId { get; set; }
        public string Password { get; set; } = string.Empty;

        public RegisterLoginDto(User user)
        {
            EmployeeId = user.EmployeeId;
        }
    }
}
