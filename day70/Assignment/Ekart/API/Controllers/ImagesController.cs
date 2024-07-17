using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly AzureBlobStorageService _blobStorageService;
        private readonly ILogger<ImagesController> _logger;

        public ImagesController(AzureBlobStorageService blobStorageService,ILogger<ImagesController> logger)
        {
            _blobStorageService = blobStorageService;
            _logger = logger;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                _logger.LogWarning("No file uploaded");
                return BadRequest("No file uploaded");
            }

            try
            {

                string imageUrl = await _blobStorageService.UploadImageAsync(file);
                _logger.LogInformation($"Image uploaded successfully {imageUrl}");
                return Ok(new { imageUrl });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading image");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error uploading image: {ex.Message}");
            }
        }
    }
}
