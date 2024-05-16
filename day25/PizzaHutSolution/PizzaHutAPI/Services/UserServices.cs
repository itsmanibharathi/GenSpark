using Microsoft.AspNetCore.Components.Forms;
using PizzaHutAPI.Exceptions;
using PizzaHutAPI.Interfaces;
using PizzaHutAPI.Models;
using PizzaHutAPI.Models.DTOs;

namespace PizzaHutAPI.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<int, User> _repository;
        public UserServices(IRepository<int,User> repository) {
            _repository = repository;
        }
        public async Task<UserDTO> Login(UserLogInDTO userLogInDTO)
        {
            var user = await _repository.Get(userLogInDTO.ID);
            if (user.Status == UserStatus.Active)
            {
                if (user.AuthenticateUser(userLogInDTO.Password))
                {
                    return new UserDTO(user);
                }
                else
                {
                    throw new FailToLoginException();
                }

            }
            else
            {
                throw new UserNotActiveException(userLogInDTO.ID);
            }
        }

        public async Task<UserDTO> Register(UserRegisterDTO userRegisterDTO)
        {
            User user = new User();
            user.SetPassword(userRegisterDTO.Password);
            user.UserInfo = new UserInfo()
            {
                Name = userRegisterDTO.Name,
                Email = userRegisterDTO.Email
            };

            await _repository.Add(user);
            return new UserDTO(user) { IsLoggedIn = true };
        }
    }
}
