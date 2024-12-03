using Application.Interfaces;
using Application.Models.Request;
using Domain.Classes;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PassengerController : ControllerBase
    {
        private readonly IPassangerService _passangerService;

        public PassengerController(IPassangerService passangerService)
        {
            _passangerService = passangerService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreatePassenger([FromBody] PassengerCreateRequest request)
        {
            var result = _passangerService.CreatePassenger(request);
            return Ok(result);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllPassengers()
        {
            return Ok(_passangerService.GetAll());
        }


        [HttpGet("id/{id}")]
        [AllowAnonymous]
        public IActionResult GetPassengerById([FromRoute] int id)
        {
            try
            {
                return Ok(_passangerService.GetPassengerById(id));
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePassenger([FromRoute] int id, [FromBody] PassengerUpdateRequest request)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _passangerService.UpdatePassenger(id, request, userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePassenger([FromRoute] int id)
        {
            try
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                _passangerService.DeletePassenger(id, userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
