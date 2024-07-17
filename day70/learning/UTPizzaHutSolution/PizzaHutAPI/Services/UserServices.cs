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
        private readonly ITokenService _tokenService;

        public UserServices(IRepository<int,User> repository , ITokenService tokenService) {
            _repository = repository;
            _tokenService = tokenService;
        }
        public async Task<ReturnLoginUserDTO> Login(UserLogInDTO userLogInDTO)
        {
            var user = await _repository.Get(userLogInDTO.ID);
            if (user.Status == UserStatus.Active)
            {
                if (user.AuthenticateUser(userLogInDTO.Password))
                {
                    var token = _tokenService.GenerateToken(user);
                    return new ReturnLoginUserDTO(user, token);
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

        public async Task<ReturnRegisterUserDTO> Register(UserRegisterDTO userRegisterDTO)
        {
            User user = new User();
            user.SetPassword(userRegisterDTO.Password);
            user.Role = userRegisterDTO.Role;
            user.UserInfo = new UserInfo()
            {
                Name = userRegisterDTO.Name,
                Email = userRegisterDTO.Email
            };

            user = await _repository.Add(user);
            return new ReturnRegisterUserDTO(user) ;
        }
    }
}
