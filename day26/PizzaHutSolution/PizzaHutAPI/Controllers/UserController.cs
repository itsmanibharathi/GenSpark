using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaHutAPI.Context;
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

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO user )
        {
            try
            {
                var result = await _userServices.Register(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogInDTO user)
        {
            try
            {
                var result = await _userServices.Login(user);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
