using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaHutAPI.Context;
using PizzaHutAPI.Exceptions;
using PizzaHutAPI.Interfaces;
using PizzaHutAPI.Models;
using PizzaHutAPI.Models.DTOs;

namespace PizzaHutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ILogger<User> _logger;

        public UserController(IUserServices userServices, ILogger<User> logger)
        {
            _userServices = userServices;
            _logger = logger;
        }

        [ProducesResponseType(typeof(ReturnRegisterUserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpPost("register")]
        public async Task<ActionResult<ReturnRegisterUserDTO>> Register(UserRegisterDTO user )
        {
            try
            {
                var result = await _userServices.Register(user);
                return Ok(result);
            }
            catch (NoUserInThisID e)
            {
                return NotFound(new ErrorMessage(StatusCodes.Status400BadRequest , e.Message ));
            }
            catch (Exception e)
            {
                return NotFound(new ErrorMessage(StatusCodes.Status500InternalServerError , e.Message));
            }
        }

        [ProducesResponseType(typeof(ReturnLoginUserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpPost("login")]
        public async Task<ActionResult<ReturnLoginUserDTO>> Login(UserLogInDTO user)
        {
            try
            {
                var result = await _userServices.Login(user);
                return Ok(result);
            }
            catch (NoUserInThisID e)
            {
                _logger.LogError(e.Message);
                return NotFound(new ErrorMessage(StatusCodes.Status400BadRequest, e.Message));
            }
            catch (Exception e)
            {
                _logger.LogCritical(e.Message);
                return Unauthorized(new ErrorMessage(StatusCodes.Status500InternalServerError ,e.Message));
            }

        }
    }
}
