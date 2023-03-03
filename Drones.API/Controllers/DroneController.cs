
using Drones.Domain.Entities;
using Drones.Domain.Enums;
using Drones.Domain.Interfaces.Services;
using Drones.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Drones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneController : ControllerBase
    {
        IDroneService _droneService;
        IMedicationService _medicationService;
        public DroneController(IDroneService droneService, IMedicationService medicationService)
        {
            _droneService = droneService;
            _medicationService = medicationService;
        }


        [HttpGet]
        [Route("GetAllDrones")]
        public async Task<IActionResult> GetAllDrones()
        {


            try
            {

                return Ok(await _droneService.GetAllDrones());
            }
            catch (Exception ex)
            {
                return BadRequest("Something Wrone Call MinaAdel For Support");
            }

        }
        // POST api/<DroneController>
        [HttpPost]
        [Route("AddDrone")]
        public async Task<IActionResult> AddDrone([FromBody] Drone drone)
        {
            try
            {
                await _droneService.InsertDrone(drone);
                return Ok("Added Drone Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Something Wrone Call MinaAdel For Support");
            }

        }

        [HttpPost]
        [Route("LoadDroneWithMedications")]

        public async Task<IActionResult> LoadDroneWithMedications([FromQuery] int SerialNumber, [FromQuery] string medicationCode)
        {
            try
            {
                await _droneService.LoadDroneWithMedicationItems(SerialNumber, medicationCode);
                return Ok("Added Drone Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Something Wrone Call MinaAdel For Support");
            }

        }
        [HttpGet]
        [Route("CheckLoadedMedicationItems")]

        public async Task<IActionResult> CheckLoadedMedicationItems([FromQuery] int SerialNumber)
        {
            try
            {
                return Ok(await _medicationService.GetLoadedModicationItems(SerialNumber));
            }
            catch (Exception ex)
            {
                return BadRequest("Something Wrone Call MinaAdel For Support");
            }

        }
        [HttpGet]
        [Route("CheckAvailDronesForLoading")]

        public async Task<IActionResult> CheckAvailDronesForLoading([FromQuery] Drone drone)
        {
            try
            {
                return Ok(await _droneService.GetAvailableDrones());
            }
            catch (Exception ex)
            {
                return BadRequest("Something Wrone Call MinaAdel For Support");
            }

        }
        [HttpGet]
        [Route("CheckDroneBatteryLevel")]

        public async Task<IActionResult> CheckDroneBatteryLevel([FromQuery] int SerialNumber)
        {
            try
            {
                return Ok(await _droneService.CheckDroneBatteryLevel(SerialNumber));
            }
            catch (Exception ex)
            {
                return BadRequest("Something Wrone Call MinaAdel For Support");
            }

        }
    }
}
