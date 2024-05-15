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
        private readonly IUserService _employeeService;

        public EmployeeController(IUserService employeeService)
        {
            _employeeService = employeeService;
        }
        [ProducesResponseType(typeof(IList<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        [HttpGet]
        public async Task<ActionResult<IList<Employee>>> Get()
        {
            Console.WriteLine("hi");
            try
            {

                var employees = await _employeeService.GetEmployees();
                return Ok(employees.ToList());
            }
            catch (NoEmployeesFoundException nefe)
            {
                return NotFound(new ErrorModel(404,nefe.Message));
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
            catch (NoEmployeesFoundException msg)
            {
                return NotFound(new ErrorModel(404, msg.Message));
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
                return NotFound(new ErrorModel(404, nefe.Message));
            }
        }

    }
}
