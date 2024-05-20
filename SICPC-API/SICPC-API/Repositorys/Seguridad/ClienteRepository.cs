using SICPC_API.Entities.Models;
using SicpcAPI.Entities.DTOs.Seguridad;
using SicpcAPI.Entities.Models;
using SicpcAPI.Repository;

namespace SicpcAPI.Repositorys.Seguridad
{
    public class ClienteRepository: Repository<Cliente>
    {
        public ClienteRepository(SicpcContext context) : base(context)
        {
            base.context = context;
        }

        public List<Cliente> ConsultarGeneral()
        {
            return context.Cliente.ToList();
        }

        public Cliente ConsultarPorId(int idCliente)
        {
            return context.Cliente.Find(idCliente);
        }

    }
}
