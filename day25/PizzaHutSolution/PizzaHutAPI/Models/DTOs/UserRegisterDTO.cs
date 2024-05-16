namespace PizzaHutAPI.Models.DTOs
{
    public class UserRegisterDTO : UserInfo
    {
        public UserRole Role { get; set; }
        public string Password { get; set; }
    }
}
