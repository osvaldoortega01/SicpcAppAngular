using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SICPC_API.Entities.Models;
using SICPC_API.Services.Seguridad;

namespace SICPC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public List<Usuario> Get()
        {
            return _usuarioService.ConsultarGeneral();
        }

        [HttpGet]
        [Route("{id}")]
        public Usuario Get(int id)
        {
            return _usuarioService.ConsultarPorId(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            return Ok(_usuarioService.Agregar(usuario));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Usuario usuario)
        {
            return Ok(_usuarioService.Editar(usuario));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioService.Eliminar(id);
            return Ok();
        }
    }
}
