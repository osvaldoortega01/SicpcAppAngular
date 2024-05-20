using Microsoft.AspNetCore.Mvc;
using SICPC_API.Entities.Models;
using SICPC_API.Services.Seguridad;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SICPC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return _clienteService.ConsultarGeneral();
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            return _clienteService.ConsultarPorId(id);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<Cliente> Post([FromBody] Cliente value)
        {
            return await _clienteService.Agregar(value);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public Cliente Put(int id, [FromBody] Cliente value)
        {
            return _clienteService.Editar(value);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _clienteService.Eliminar(id);
        }
    }
}
