using AutoMapper;
using EmployeeRequestTracker.Exceptions;
using EmployeeRequestTracker.Interfaces;
using EmployeeRequestTracker.Models;
using EmployeeRequestTracker.Models.ModelsDTOs;

namespace EmployeeRequestTracker.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<int, Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReturnEmployeeDto> Add(EmployeeDto employeeDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);
            return _mapper.Map<ReturnEmployeeDto>(await _repository.Add(employee));
        }

        public async Task<ReturnEmployeeDto> Get(int key)
        {
            return _mapper.Map<ReturnEmployeeDto>( await _repository.Get(key));
        }

        public async Task<IEnumerable<ReturnEmployeeDto>> Get()
        {
            return _mapper.Map<IEnumerable<ReturnEmployeeDto>>(await _repository.Get());  
        }
    }
}
