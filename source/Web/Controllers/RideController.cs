using System.Security.Claims;
using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RideController : ControllerBase
    {
        private readonly IRideService _rideService;
        private readonly IPassangerService _passangerService;
        public RideController(IRideService rideService, IPassangerService passangerService)
        {
            _rideService = rideService;
            _passangerService = passangerService;
        }

        [HttpPost]
        public IActionResult CreateRide([FromBody] RideCreateRequest request)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;
            if (userRole != "Passenger")
            {
                return Unauthorized();
            }

            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var result = _rideService.CreateRide(request, userId);
            return Ok(result);  
        }


        [HttpGet("[action]")]
        public IActionResult GetAllRides()
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;
            if (userRole != "Driver") return BadRequest("Acceso denegado");

            return Ok(_rideService.GetAllRides());
        }


        [HttpGet("id/{id}")]
        public IActionResult GetRideById(int id)
        {
            try
            {
                return Ok(_rideService.GetRideById(id));
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("[action]/{passengerId}")]
        public IActionResult GetRidesByPassenger(int passengerId)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

            if (userRole != "Passenger" || userId != passengerId) return BadRequest("Acceso denegado");
            var rides = _rideService.GetRidesByPassenger(passengerId);
            return Ok(rides);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateRide([FromRoute] int id, [FromBody] RideUpdateRequest request)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _rideService.UpdateRide(id, request, userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteRide([FromRoute] int id)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _rideService.DeleteRide(id, userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
