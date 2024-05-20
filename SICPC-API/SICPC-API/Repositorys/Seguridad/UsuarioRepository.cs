using SICPC_API.Entities.Models;
using SicpcAPI.Entities.DTOs.Seguridad;
using SicpcAPI.Entities.Models;
using SicpcAPI.Repository;

namespace SicpcAPI.Repositorys.Seguridad
{
    public class UsuarioRepository: Repository<Usuario>
    {
        public UsuarioRepository(SicpcContext context) : base(context)
        {
            base.context = context;
        }

        public List<Usuario> ConsultarGeneral()
        {
            return context.Usuario.ToList();
        }

        public Usuario ConsultarPorId(int idUsuario)
        {
            return context.Usuario.Find(idUsuario);
        }

        public List<UsuarioDTO> ConsultarGeneralDTO()
        {
            return context.Usuario
                .Select(u => new UsuarioDTO
                {
                    Correo = u.Correo,
                    Nombre = u.NombreCompleto,
                })
                .ToList();
        }

        public Usuario? ConsultarPorUserName(string username)
        {
            return context.Usuario
                .Where(u => u.Username == username)
                .FirstOrDefault();
        }

        public Usuario? ConsultarPorCorreo(string correo)
        {
            return context.Usuario
                .Where(u => u.Correo == correo)
                .FirstOrDefault();
        }
    }
}
