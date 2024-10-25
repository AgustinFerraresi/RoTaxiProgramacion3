using Application.Interfaces;
using Application.Models;
﻿using System.Security.Claims;
using Application.Models.Request;
using Application.Services;
using Domain.Classes;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create([FromBody] DriverCreateRequest request)
        {
            var result = _driverService.CreateDriver(request);
            return Ok(result);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            return Ok(_driverService.GetAllDrivers());
        }


        [HttpGet("id/{id}")]
        public IActionResult GetDriverById([FromRoute] int id)
        {
            try
            {
                return Ok(_driverService.GetDriverById(id));
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteDriver([FromRoute] int id)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _driverService.DeleteDriver(id, userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateDriver([FromRoute]  int id, [FromBody] DriverUpdateRequest request) 
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _driverService.UpdateDriver(id, request, userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("[action]/{driverId}")]
        public IActionResult GetDriverVehicles(int driverId)
        {
            var result = _driverService.GetAllDriverVehicles(driverId);
            if (result == null)
            {
                return NotFound("Error al buscar el conductor.");
            }
            if (result.Count == 0)
            {
                return BadRequest("El conductor no tiene vehiculos");
            }
            return Ok(result);
        }


        [HttpPost("[action]/{driverId}/{vehicleId}")]
        public IActionResult AddVehicle(int driverId, int vehicleId)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

                var result = _driverService.AddVehicle(driverId, vehicleId, userId);
                return result ? Ok("Vehiculo agregado") : BadRequest("Error al agregar vehiculo.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("[action]/{driverId}/{vehicleId}")]
        public IActionResult DeleteDriverVehicle(int driverId, int vehicleId)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                var result = _driverService.DeleteDriverVehicle(driverId, vehicleId, userId);
                return result ? Ok("Vehiculo eliminado correctamente.") : BadRequest("Error al eliminar el vehículo");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // SACAR EL COMENTADO DESPUES EL METODO EL METODO SIRVE
        //[HttpPost("[action]/{driverId}/{rideId}")]
        //public IActionResult TakeARide(int driverId, int rideId)
        //{
        //    var result = _driverService.AcceptDrive(driverId, rideId);
        //    if (result == true)
        //    {
        //        return Ok("Viaje aceptado correctamente");
        //    }
        //    return BadRequest("Error al intentar aceptar el viaje");
        //}
    }  
}
