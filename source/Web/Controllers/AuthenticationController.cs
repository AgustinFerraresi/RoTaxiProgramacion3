using Application.Interfaces;
using Application.Models.Request;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        [HttpPost("authenticate")]
        public ActionResult<string> Autenticar([FromBody] AuthenticationRequest request)
        {
            try
            {
                string token = _authenticateService.Autenticar(request);
                return Ok(token);
            }
            catch
            {
                return Unauthorized();
            }

        }
    }
}
