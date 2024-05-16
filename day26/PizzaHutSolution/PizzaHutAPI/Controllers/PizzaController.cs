using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaHutAPI.Exceptions;
using PizzaHutAPI.Interfaces;
using PizzaHutAPI.Models;

namespace PizzaHutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [ProducesResponseType(typeof(Pizza),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage),StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<Pizza>> AddPizza(Pizza pizza)
        {
            try
            {
                
                return Ok(await _pizzaService.Add(pizza));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessage(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [ProducesResponseType(typeof(Pizza),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorMessage),StatusCodes.Status500InternalServerError)]
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            try
            {
                return await _pizzaService.Get(id);
            }
            catch (NoPizzaInThisID ex)
            {
                return NotFound(new ErrorMessage(StatusCodes.Status404NotFound, ex.Message));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessage(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [ProducesResponseType(typeof(IEnumerable<Pizza>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorMessage),StatusCodes.Status500InternalServerError)]

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetMenuItems()
        {
            try
            {
                return Ok(await _pizzaService.GetMenuItems());
            }
            catch (EmptyDBException )
            {
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessage(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [ProducesResponseType(typeof(IEnumerable<Pizza>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorMessage),StatusCodes.Status500InternalServerError)]
        [Route("AllPizzas")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
            try
            {
                return Ok(await _pizzaService.Get());
            }
            catch (EmptyDBException ex)
            {
                return NotFound(new ErrorMessage(StatusCodes.Status404NotFound, ex.Message));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessage(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [ProducesResponseType(typeof(Pizza),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage),StatusCodes.Status500InternalServerError)]

        [Route("UpdateQty")]
        [HttpPut]
        public async Task<ActionResult<Pizza>> UpdatePizzaQty(int id, int count)
        {
            try
            {
                return await _pizzaService.UpdatePizzaQty(id, count);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Pizza),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]

        [HttpPut("MakeAvalable/{id}")]
        public async Task<ActionResult<Pizza>> MakeAvalable(int id)
        {
            try
            {
                return await _pizzaService.MackeAvalable(id);
            }
            catch (AlreadyUpToDateException ex)
            {
                return StatusCode(StatusCodes.Status304NotModified, "Pizza Is Already in Avalable");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("MakeUnAvalable/{id}")]
        public async Task<ActionResult<Pizza>> MakeUnAvalable(int id)
        {
            try
            {
                return await _pizzaService.MakeUnAvalable(id);
            }
            catch (AlreadyUpToDateException ex)
            {
                return StatusCode(StatusCodes.Status304NotModified, "Pizza Is Already in UnAvalable");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
