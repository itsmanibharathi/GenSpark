namespace PizzaHutAPI.Models.DTOs
{
    public class ReturnLoginUserDTO
    {
        public int Id { get; set; }
        public UserRole Role { get; set; }
        public UserStatus Status { get; set; }
        public bool IsLoggedIn { get; set; } = false;

        public string Jwt { get; set; }

        /// <summary>
        /// Return Login User Model 
        /// </summary>
        /// <param name="user"> User Object</param>
        /// <param name="jwt"> Jwt Token </param>
        public ReturnLoginUserDTO(User user , string jwt)
        {
            Id = user.Id;
            Role = user.Role;
            Status = user.Status;
            Jwt = jwt;
        }
    }
}
