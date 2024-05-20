using System.Security.Cryptography;

namespace EmployeeRequestTracker.Models
{
    public enum UserStatus
    {
        Active,
        Inactive,
        NewUser
    }
    public class User
    {
        public int EmployeeId { get; set; }
        public byte[] PasswordHashKey { get; set; }
        public byte[] PasswordHash { get; set; }
        public UserStatus Status { get; set; } = UserStatus.NewUser;
        public Employee? employee { get; set; }

        public bool CheckPassword(string password)
        {
            HMACSHA256 hMACSHA = new HMACSHA256(PasswordHashKey);
            byte[] passwordHash = hMACSHA.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            if (passwordHash.Length != PasswordHash.Length)
            {
                return false;
            }
            for (int i = 0; i < passwordHash.Length; i++)
            {
                if (passwordHash[i] != PasswordHash[i])
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
            PasswordHash = hMACSHA.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
