using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHutAPI.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }=DateTime.Now;
        public DateTime? UpdateAt { get; set; }
        public User User { get; set; }
    }
}
