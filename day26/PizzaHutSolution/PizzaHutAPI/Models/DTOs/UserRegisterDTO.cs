namespace PizzaHutAPI.Models.DTOs
{
    public class UserRegisterDTO 
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public string Password { get; set; }
    }
}
