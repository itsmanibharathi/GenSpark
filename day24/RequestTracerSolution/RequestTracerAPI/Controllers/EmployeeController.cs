using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestTracerAPI.Exceptions;
using RequestTracerAPI.Interfaces;
using RequestTracerAPI.Models;
using System.Numerics;

namespace RequestTracerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<IList<Employee>>> Get()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();
                return Ok(employees.ToList());
            }
            catch (NoEmployeesFoundException nefe)
            {
                return NotFound(nefe.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Employee>> Put(int id, string phone)
        {
            try
            {
                var employee = await _employeeService.UpdateEmployeePhone(id, phone);
                return Ok(employee);
            }
            catch (NoEmployeesFoundException nsee)
            {
                return NotFound(nsee.Message);
            }
        }
        [Route("GetEmployeeByPhone")]
        [HttpPost]
        public async Task<ActionResult<Employee>> Get([FromBody] string phone)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByPhone(phone);
                return Ok(employee);
            }
            catch (NoEmployeesFoundException nefe)
            {
                return NotFound(nefe.Message);
            }
        }

    }
}
