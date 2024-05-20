using AutoMapper;
using EmployeeRequestTracker.Exceptions;
using EmployeeRequestTracker.Interfaces;
using EmployeeRequestTracker.Models;
using EmployeeRequestTracker.Models.ModelsDTOs;

namespace EmployeeRequestTracker.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _repository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, User> repository , IMapper mapper, ITokenService tokenService
            )
        {
            _repository = repository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<ReturnRegisterDto> SetUpPassword(RegisterLoginDto loginDto)
        {
            User user = new User
            {
                EmployeeId = loginDto.EmployeeId
            };
            user.SetPassword(loginDto.Password);
            var res = await _repository.Add(user);
            return _mapper.Map<ReturnRegisterDto>(res);
        }

        public async Task<ReturnLoginDto> Login(RegisterLoginDto loginDto)
        {
            User user = await _repository.Get(loginDto.EmployeeId);
            if (!user.CheckPassword(loginDto.Password))
                throw new FailToLoginException();
            string token =  _tokenService.GenerateToken(user);
            var returnLoginDto = _mapper.Map<ReturnLoginDto>(user);
            returnLoginDto.Token = token;
            return returnLoginDto;
        }

        public async Task<ReturnRegisterDto> Activate(int EmployeeId)
        {
            User user = _repository.Get(EmployeeId).Result;
            user.Status = UserStatus.Active;
            var res = await _repository.Update(user);
            return _mapper.Map<ReturnRegisterDto>(res);
        }

        public async Task<ReturnRegisterDto> Deactivate(int EmployeeId)
        {
            User user = _repository.Get(EmployeeId).Result;
            user.Status = UserStatus.Inactive;
            var res = await _repository.Update(user);
            return _mapper.Map<ReturnRegisterDto>(res);
        }
    }
}
