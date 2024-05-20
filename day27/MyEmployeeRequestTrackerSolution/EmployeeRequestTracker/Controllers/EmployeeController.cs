using EmployeeRequestTracker.Exceptions;
using EmployeeRequestTracker.Interfaces;
using EmployeeRequestTracker.Models.ModelsDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequestTracker.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeSercice;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeSercice = employeeService;
        }

        [HttpPost("/Add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReturnEmployeeDto))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ReturnError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ReturnError))]
        public async Task<IActionResult> AddEmployee(EmployeeDto employeeDto)
        {
            try
            {
                var res = await _employeeSercice.Add(employeeDto);
                return Ok(res);
            }
            catch (AlreadyExistsException ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status409Conflict,ex.Message));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status500InternalServerError,ex.Message));
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReturnEmployeeDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ReturnError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ReturnError))]

        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var res = await _employeeSercice.Get();
                return Ok(res);
            }
            catch (EmptyDBException ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status204NoContent,ex.Message));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status500InternalServerError,ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var res = await _employeeSercice.Get(id);
                return Ok(res);
            }
            catch (NoEmployeeInThisID ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status204NoContent, ex.Message));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }
    }
}
