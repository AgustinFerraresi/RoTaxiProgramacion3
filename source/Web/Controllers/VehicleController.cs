using System.Security.Claims;
using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Classes;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost]
        public IActionResult CreateVehicle([FromBody] CreateVehicleRequest request)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var userRole = User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;
            if (userRole != "Driver")
            {
                return Unauthorized();
            }

            VehicleDto result = _vehicleService.CreateVehicle(request, userId);
            return Ok(result);
        }


        [HttpGet]
        public IActionResult GetAllVehicles()
        {
            List<VehicleDto> vehicles = _vehicleService.GetAllVehicles();
            if (vehicles.Count > 0)
            {
                return Ok(vehicles);
            }
            return Ok("No hay vehiculos");
        }


        [HttpGet("id/{id}")]
        public IActionResult GetVehicleById(int id)
        {
            var vehicle = _vehicleService.GetVehicleById(id);
            if (vehicle != null)
            {
                return Ok(vehicle);
            }

            return BadRequest("Vehiculo no encontrado");
        }


        [HttpGet("[action]/{vehicleId}")]
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


        [HttpPut("{id}")]
        public IActionResult UpdateVehicle([FromBody] VehicleUpdateRequest request, int id)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var result = _vehicleService.UpdateVehicle(request, id, userId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error al actualizar el vehiculo");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

            var result = _vehicleService.DeleteVehicle(id, userId);
            return result ? Ok("El vehiculo se eliminó exitosamente") : Ok("Error el eliminar el vehiculo");
        }
    }
}