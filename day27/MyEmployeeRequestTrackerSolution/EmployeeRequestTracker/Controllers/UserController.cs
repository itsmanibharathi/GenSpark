using EmployeeRequestTracker.Exceptions;
using EmployeeRequestTracker.Interfaces;
using EmployeeRequestTracker.Models.ModelsDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequestTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("/SetUpPassword")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReturnRegisterDto))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ReturnError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ReturnError))]
        public async Task<IActionResult> SetUpPassword(RegisterLoginDto loginDto)
        {
            try
            {
                var res = await _userService.SetUpPassword(loginDto);
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

        [HttpPost("/Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReturnLoginDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ReturnError))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ReturnError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ReturnError))]
        public async Task<IActionResult> Login(RegisterLoginDto loginDto)
        {
            try
            {
                var res = await _userService.Login(loginDto);
                return Ok(res);
            }
            catch (FailToLoginException ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status400BadRequest,ex.Message));
            }
            catch (NoUserInThisID ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status404NotFound,ex.Message));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status500InternalServerError,ex.Message));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("/Activate")]
        public async Task<IActionResult> Activate(int EmployeeId)
        {
            try
            {
                var res = await _userService.Activate(EmployeeId);
                return Ok(res);
            }
            catch (NoUserInThisID ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status404NotFound,ex.Message));
            }
            catch (AlreadyUpToDateException ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status409Conflict,ex.Message));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status500InternalServerError,ex.Message));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("/Deactivate")]
        public async Task<IActionResult> Deactivate(int EmployeeId)
        {
            try
            {
                var res = await _userService.Deactivate(EmployeeId);
                return Ok(res);
            }
            catch (NoUserInThisID ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status404NotFound,ex.Message));
            }
            catch (AlreadyUpToDateException ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status409Conflict,ex.Message));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnError(StatusCodes.Status500InternalServerError,ex.Message));
            }
        }
    }
}
