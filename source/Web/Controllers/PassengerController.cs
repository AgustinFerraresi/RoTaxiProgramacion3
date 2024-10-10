using Application.Interfaces;
using Application.Models.Request;
using Domain.Classes;
using Domain.Exceptions;
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
        public IActionResult CreatePassenger([FromBody] PassengerCreateRequest request)
        {
            var result =  _passangerService.CreatePassenger(request);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllPassenger()
        {
            return Ok(_passangerService.GetAllPassenger());
        }

        [HttpGet("id/{id}")]
        public IActionResult GetPassengerById(int id) 
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

        [HttpDelete("{id}")]
        public IActionResult DeletePassenger([FromRoute] int id)
        {
            try
            {
                _passangerService.DeletePassenger(id);
                return NoContent();
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
                _passangerService.UpdatePassenger(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
