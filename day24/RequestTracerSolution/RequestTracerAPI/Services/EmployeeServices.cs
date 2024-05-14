using RequestTracerAPI.Exceptions;
using RequestTracerAPI.Interfaces;
using RequestTracerAPI.Models;


namespace RequestTracerAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _repository;

        public EmployeeService(IRepository<int, Employee> reposiroty)
        {
            _repository = reposiroty;
        }
        public async Task<Employee> GetEmployeeByPhone(string phoneNumber)
        {
            var employee = (await _repository.Get()).FirstOrDefault(e => e.PhoneNumber == phoneNumber);
            if (employee == null)
                throw new NoEmployeesFoundException();
            return employee;

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _repository.Get();
            if (employees.Count() == 0)
                throw new NoEmployeesFoundException();
            return employees;
        }

        public async Task<Employee> UpdateEmployeePhone(int id, string phoneNumber)
        {
            var employee = await _repository.Get(id);
            if (employee == null)
                throw new NoEmployeesFoundException();
            employee.PhoneNumber = phoneNumber;
            employee = await _repository.Update(employee);
            return employee;
        }
    }
}
