
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRequestTrackerAPI.Models
{
    public enum UserStatus
    {
        Active,
        Inactive,
        NewUser
    }
    public class User
    {
        [Key]
        public int EmployeeId { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordHashKey { get; set; } 

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public UserStatus Status { get; set; }
    }
}   
