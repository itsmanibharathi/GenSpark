namespace PizzaHutAPI.Models.DTOs
{
    public class ReturnRegisterUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public UserStatus Status { get; set; }

        public ReturnRegisterUserDTO(User user)
        {
            Id = user.Id;
            Name = user.UserInfo.Name;
            Role = user.Role;
            Status = user.Status;
        }
    }
}
