using EmployeeRequestTracker.Exceptions;
using EmployeeRequestTracker.Interfaces;
using EmployeeRequestTracker.Models;
using EmployeeRequestTracker.Models.ModelsDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequestTracker.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Request))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ReturnError))]
        public async Task<IActionResult> AddRequest(GetRequestDto request)
        {
            try
            {
                var res = await _requestService.Add(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status500InternalServerError,ex.Message));
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Request>))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ReturnError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ReturnError))]

        public async Task<IActionResult> GetRequests()
        {
            try
            {
                var res = await _requestService.Get();
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
    }
}
