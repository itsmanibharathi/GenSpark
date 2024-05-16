using PizzaHutAPI.Models;
using PizzaHutAPI.Models.DTOs;

namespace PizzaHutAPI.Interfaces
{
    public interface IUserServices
    {
        public Task<ReturnRegisterUserDTO> Register(UserRegisterDTO user);
        public Task<ReturnLoginUserDTO> Login(UserLogInDTO user);
    }
}
