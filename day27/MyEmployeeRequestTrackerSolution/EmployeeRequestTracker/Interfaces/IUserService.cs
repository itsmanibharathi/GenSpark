using EmployeeRequestTracker.Models.ModelsDTOs;

namespace EmployeeRequestTracker.Interfaces
{
    public interface IUserService
    {
        public Task<RegisterLoginDto> SetUpPassword(RegisterLoginDto loginDto);
        public Task<ReturnLoginDto> Login(RegisterLoginDto loginDto);
        public Task<ReturnEmployeeDto> Activate(int EmployeeId);
        public Task<ReturnEmployeeDto> Deactivate(int EmployeeId);
    }
}
