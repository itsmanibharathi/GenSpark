using EmployeeRequestTracker.Models;

namespace EmployeeRequestTracker.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user );
    }
}
