using RequestTracerAPI.Models;
using RequestTracerAPI.Models.DTOs;

namespace RequestTracerAPI.Interfaces
{
    public interface IUserService
    {

        public Task<Employee> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeDTO);
    }
}
