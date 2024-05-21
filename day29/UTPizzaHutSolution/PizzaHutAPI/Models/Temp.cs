using System.ComponentModel.DataAnnotations;

namespace PizzaHutAPI.Models
{
    public class Temp
    {
        [Key]
        public int Id { get; set; }
        public byte[] Password;
        public byte[] PasswordHashKey;
    }
}
