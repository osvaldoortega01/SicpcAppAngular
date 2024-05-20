using Microsoft.AspNetCore.Mvc;
using SICPC_API.Entities.Models;
using SICPC_API.Services.Seguridad;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SICPC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly ServicioService _servicioService;

        public ServicioController(ServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        // GET: api/<ServicioController>
        [HttpGet]
        public IEnumerable<Servicio> Get()
        {
            return _servicioService.ConsultarGeneral();
        }

        // GET api/<ServicioController>/5
        [HttpGet("{id}")]
        public Servicio Get(int id)
        {
            return _servicioService.ConsultarPorId(id);
        }

        // POST api/<ServicioController>
        [HttpPost]
        public async Task<Servicio> Post([FromBody] Servicio value)
        {
            return await _servicioService.Agregar(value);
        }

        // PUT api/<ServicioController>/5
        [HttpPut("{id}")]
        public Servicio Put(int id, [FromBody] Servicio value)
        {
            return _servicioService.Editar(value);
        }

        // DELETE api/<ServicioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _servicioService.Eliminar(id);
        }
    }
}
