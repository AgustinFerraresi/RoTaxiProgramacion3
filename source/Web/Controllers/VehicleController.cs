using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Classes;
using Domain.Interfaces;
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

        //en los parametros van los dto
        //la responsabilidad de los controllers tiene que ser netamente de interfaz osea, es como un pasa mano,
        //no tiene que crear nada ningun objeto ni nada por el estilo, crear un objeto es algo que le corresponde a un 
        //servicio
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
    }
}
