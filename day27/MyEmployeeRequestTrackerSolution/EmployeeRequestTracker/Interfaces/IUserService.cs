using EmployeeRequestTracker.Models.ModelsDTOs;

namespace EmployeeRequestTracker.Interfaces
{
    public interface IUserService
    {
        public Task<ReturnRegisterDto> SetUpPassword(RegisterLoginDto loginDto);
        public Task<ReturnLoginDto> Login(RegisterLoginDto loginDto);
        public Task<ReturnRegisterDto> Activate(int EmployeeId);
        public Task<ReturnRegisterDto> Deactivate(int EmployeeId);
    }
}
