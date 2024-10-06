using Application.Interfaces;
using Application.Request;
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

        [HttpGet("[action]")]
        public IActionResult CreateDriver([FromBody]DriverRequest request)
        {
            var result = _driverService.CreateDriver(request);
            return Ok(result);
        }

    }
}
