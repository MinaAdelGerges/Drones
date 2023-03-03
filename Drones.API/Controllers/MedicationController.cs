using Drones.Domain.Entities;
using Drones.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Drones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly IMedicationService _medicationService;
        public MedicationController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }
        // GET: api/<MedicationController>
        [HttpGet]
        [Route("GetAllMedications")]
        public async Task<IActionResult> GetAllMedications()

        {
            try
            {
                return Ok(await _medicationService.GetAllAsync());

            }
            catch (Exception ex)
            {
                return BadRequest("Something Wrong");

            }
        }
        [HttpPost]
        [Route("AddMedication")]
        public async Task<IActionResult> AddMedication(Medication medication)

        {
            try
            {
                return Ok(await _medicationService.InsertAsync(medication));

            }
            catch (Exception ex)
            {
                return BadRequest("Something Wrong");

            }
        }
    }
}
