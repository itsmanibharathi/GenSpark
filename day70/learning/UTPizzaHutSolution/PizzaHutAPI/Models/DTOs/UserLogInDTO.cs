using System.ComponentModel.DataAnnotations;

namespace PizzaHutAPI.Models.DTOs
{
    public class UserLogInDTO
    {
        [Required(ErrorMessage = "ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "ID must be greater than 0")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; } = "";
    }
}
