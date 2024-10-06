using Application.Interfaces;
using Application.Request;
using Domain.Classes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassangerService _passangerService;

        public PassengerController(IPassangerService passangerService)
        {
            _passangerService = passangerService;
        }

        [HttpPost("[action]")]
        public IActionResult CreatePassenger([FromBody] PassengerRequest request)
        {
            var result =  _passangerService.CreatePassenger(request);
            return Ok(result);
        }

        //[HttpPost("[action]")]
        //public IActionResult DeleteVehicle(Vehicle vehicle)
        //{
        //    _vehicleService.DeleteVehicle(vehicle);
        //    return Ok("Vehiculo eliminado correctamente");
        //}

        //[HttpGet("[action]")]
        //public IActionResult GetAllVehicles()
        //{
        //    List<Vehicle> vehicles = _vehicleService.GetAllVehicles();
        //    return Ok(vehicles);
        //}

        //[HttpGet]
        //public IActionResult GetVehicleById([FromBody] int id)
        //{
        //    Vehicle vehicle = _vehicleService.GetVehicleById(id);
        //    if (vehicle != null)
        //    {
        //        return Ok(vehicle);
        //    }

        //    return BadRequest(vehicle);
        //}
    }
}
