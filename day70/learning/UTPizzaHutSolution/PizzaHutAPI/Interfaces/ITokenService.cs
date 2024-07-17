using PizzaHutAPI.Models;
using PizzaHutAPI.Models.DTOs;

namespace PizzaHutAPI.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
