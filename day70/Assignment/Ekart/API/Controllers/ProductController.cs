using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpPost]

        public async Task<IActionResult> Add(Product item)
        {
            try
            {
                var result = await _productService.Add(item);
                var res = new Response<Product>(result, StatusCodes.Status201Created);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to add product");
                var res = new Response( StatusCodes.Status500InternalServerError, "Unable to add product");
                return StatusCode(StatusCodes.Status500InternalServerError, res);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _productService.Get();
                var res = new Response<IEnumerable<Product>>(result, StatusCodes.Status200OK);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to get products");
                var res = new Response(StatusCodes.Status500InternalServerError, "Unable to get products");
                return StatusCode(StatusCodes.Status500InternalServerError, res);
            }
        }
    }
}
