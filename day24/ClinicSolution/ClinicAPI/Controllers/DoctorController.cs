using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService )
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> Get()
        {
            try
            {
                var res = await _doctorService.Get();
                return Ok(res);
            }
            catch (EmptyDataBaseException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Route("BySpecialization/{specialization}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetBySpecialization(string specialization)
        {
            try
            {
                var res = await _doctorService.GetBySpecialization(specialization);
                return Ok(res);
            }
            catch (NoDoctorFoundInThisSpecializationException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
