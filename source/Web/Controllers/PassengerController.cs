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
        public IActionResult Create([FromBody] PassengerCreateRequest request)
        {
            var result =  _passangerService.Create(request);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_passangerService.GetAll());
        }

        [HttpGet("id/{id}")]
        public IActionResult GetPassengerById(int id) 
        {
            try
            {
                return Ok(_passangerService.GetById(id));
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _passangerService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PassengerUpdateRequest request)
        {
            try
            {
                _passangerService.Update(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
