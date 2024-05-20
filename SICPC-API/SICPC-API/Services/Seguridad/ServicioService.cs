using SendGrid;
using SendGrid.Helpers.Mail;
using SICPC_API.Entities.Models;
using SicpcAPI.Entities.DTOs.Seguridad;
using SicpcAPI.Repositorys.Seguridad;
using System.Net.Mail;

namespace SICPC_API.Services.Seguridad
{
    public class ServicioService
    {
        private readonly ServicioRepository _servicioRepository;

        public ServicioService(
            ServicioRepository servicioRepository
            )
        {
            _servicioRepository = servicioRepository;
        }

        public List<Servicio> ConsultarGeneral()
        {
            return _servicioRepository.ConsultarGeneral();
        }

        public Servicio ConsultarPorId(int idServicio)
        {
            return _servicioRepository.ConsultarPorId(idServicio);
        }

        public async Task<Servicio> Agregar(Servicio servicio)
        {
            return _servicioRepository.Agregar(servicio);
        }

        public Servicio Editar(Servicio servicio)
        {
            _servicioRepository.Editar(servicio);
            return servicio;
        }

        public void Eliminar(int idServicio)
        {

            _servicioRepository.Eliminar(ConsultarPorId(idServicio));
        }

    }
}
