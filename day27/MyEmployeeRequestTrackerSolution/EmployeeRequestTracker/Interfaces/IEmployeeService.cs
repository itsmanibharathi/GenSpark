using EmployeeRequestTracker.Models;
using EmployeeRequestTracker.Models.ModelsDTOs;

namespace EmployeeRequestTracker.Interfaces
{
    public interface IEmployeeService
    {
        public Task<ReturnEmployeeDto> Add(EmployeeDto employeeDto);
        public Task<ReturnEmployeeDto> Get(int key);
        public Task<IEnumerable<ReturnEmployeeDto>> Get();
    }
}
