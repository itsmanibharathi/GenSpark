namespace PizzaHutAPI.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public UserRole Role { get; set; }
        public UserStatus Status { get; set; }
        public bool IsLoggedIn { get; set; } = false;

        public UserDTO(User user)
        {
            Id = user.Id;
            Role = user.Role;
            Status = user.Status;
        }
    }
}
