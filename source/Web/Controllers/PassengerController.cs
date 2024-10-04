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

        //inyectar userRepo en userService
        //userService inyectar en este controller
        //guardar los usuario en una lista estatica en el repo mas adelante lo hacemos en la bd
        //[HttpPost]
        //public IActionResult CreateUser([FromBody]string name,string email,string password,int dni,string message,string location,string destination)
        //{

        //}
        [HttpGet]
        public IActionResult a()
        {
            return Ok("");
        }
    }
}
