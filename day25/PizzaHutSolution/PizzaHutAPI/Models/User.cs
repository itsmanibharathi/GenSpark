using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
namespace PizzaHutAPI.Models
{
    public enum UserRole
    {
        Admin,
        User
    }
    public enum UserStatus
    {
        Active,
        InActive,
        Blocked,
        newUser
    }
    public class User
    {
        public int Id { get; set; }
        [Column("Password")]
        public byte[] Password { get; set; }

        [Column("PasswordHashKey")]
        public byte[] PasswordHashKey { get; set; }


        public UserRole Role { get; set; }  = UserRole.User;
        public UserStatus Status { get; set; } = UserStatus.newUser;
        public UserInfo? UserInfo { get; set; }

        public bool AuthenticateUser(string password)
        {
            HMACSHA256 hMACSHA = new HMACSHA256(PasswordHashKey);
            byte[] passwordHash = hMACSHA.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            if (passwordHash.Length != Password.Length)
            {
                return false;
            }
            for (int i = 0; i < passwordHash.Length; i++)
            {
                if (passwordHash[i] != Password[i])
                {
                    return false;
                }
            }
            return true;
        }
        public void SetPassword(string password)
        {
            HMACSHA256 hMACSHA = new HMACSHA256();
            PasswordHashKey = hMACSHA.Key;
            Password = hMACSHA.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
