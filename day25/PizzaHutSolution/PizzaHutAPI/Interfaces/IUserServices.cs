using PizzaHutAPI.Models;
using PizzaHutAPI.Models.DTOs;

namespace PizzaHutAPI.Interfaces
{
    public interface IUserServices
    {
        public Task<UserDTO> Register(UserRegisterDTO user);
        public Task<UserDTO> Login(UserLogInDTO user);
    }
}
