using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestTracerAPI.Models
{
    public enum UserStatus
    {
        Active,
        Inactive,
        Disabled
    }
    public class User
    {
        [Key]
        public int EmployeeId { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordHashKey { get; set; }
        public UserStatus Status { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

    }
}
