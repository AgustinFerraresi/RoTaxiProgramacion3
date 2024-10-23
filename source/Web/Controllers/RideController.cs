using System.Security.Claims;
using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Application.Services;
using Domain.Classes;
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

        [HttpPost("[action]")]
        
        public IActionResult CreateRide([FromBody] RideCreateRequest request)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;
            if (userRole != "Passenger")
            {
                return Unauthorized();
            }

            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var result = _rideService.CreateRide(request, userId);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_rideService.GetAll());
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_rideService.GetById(id));
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] RideUpdateRequest request)
        {
            try
            {
                _rideService.Update(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _rideService.Delete(id, userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
