using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Classes;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost("[action]")]
        public IActionResult CreateVehicle([FromBody] CreateVehicleRequest request)
        {
            VehicleDto result = _vehicleService.CreateVehicle(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            var result = _vehicleService.DeleteVehicle(id);
            return result ? Ok("El vehiculo se eliminó exitosamente") : Ok("Error el eliminar el vehiculo");
        }

        [HttpGet("[action]")]
        public IActionResult GetAllVehicles()
        {
            List<VehicleDto> vehicles = _vehicleService.GetAllVehicles();
            return Ok(vehicles);            
        }

        [HttpGet("id/{id}")]
        public IActionResult GetVehicleById(int id)
        {
            var vehicle = _vehicleService.GetVehicleById(id);
            if (vehicle != null)
            {
                return Ok(vehicle);
            }

            return BadRequest(vehicle);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle([FromBody] VehicleUpdateRequest request, int id)
        {
            var result = _vehicleService.UpdateVehicle(request, id);
            return Ok(result);
        }

        [HttpGet("[action]{vehicleId}")]
        public IActionResult GetDriversVehicle(int vehicleId)
        {
            List<DriverDto>? driversList = _vehicleService.GetAllDrivers(vehicleId);

            if (driversList == null)
            {
                return BadRequest("Vehiculo no encontrado");
            }

            if (driversList.Count == 0)
            {
                return Ok("El vehiculo no tiene conductores");
            }

            return Ok(driversList);
        }
    }
}