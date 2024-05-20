using SICPC_API.Entities.Models;
using SicpcAPI.Entities.DTOs.Seguridad;
using SicpcAPI.Entities.Models;
using SicpcAPI.Repository;

namespace SicpcAPI.Repositorys.Seguridad
{
    public class ServicioRepository: Repository<Servicio>
    {
        public ServicioRepository(SicpcContext context) : base(context)
        {
            base.context = context;
        }

        public List<Servicio> ConsultarGeneral()
        {
            return context.Servicio.ToList();
        }

        public Servicio ConsultarPorId(int idServicio)
        {
            return context.Servicio.Find(idServicio);
        }

    }
}
