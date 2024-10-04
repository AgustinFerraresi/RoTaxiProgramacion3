using Application.Interfaces;
using Domain.Classes;
using Microsoft.AspNetCore.Mvc;


namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost("[action]")]
        public IActionResult RegisterDriver([FromBody] string name, string email,string password, int dni)
        {
            var newDriver = new Driver(name, email, password, dni);
 
            _driverService.RegisterDriver(newDriver);
            return Ok(newDriver);
        }

    }
}
