using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SICPC_API.Services.Seguridad;
using SicpcAPI.Entities.Models.Seguridad;
using SicpcAPI.Helpers;

namespace SICPC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var usuario = _loginService.Login(loginRequest);
            return Ok(usuario);
        }
    }
}
