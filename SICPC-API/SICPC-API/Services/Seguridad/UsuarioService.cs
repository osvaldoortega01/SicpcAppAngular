using SICPC_API.Entities.Models;
using SicpcAPI.Entities.DTOs.Seguridad;
using SicpcAPI.Repositorys.Seguridad;

namespace SICPC_API.Services.Seguridad
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(
            UsuarioRepository usuarioRepository
            )
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<Usuario> ConsultarGeneral()
        {
            return _usuarioRepository.ConsultarGeneral();
        }

        public Usuario ConsultarPorId(int idUsuario)
        {
            return _usuarioRepository.ConsultarPorId(idUsuario);
        }

        public Usuario ConsultarPorCorreo(string correo)
        {
            return _usuarioRepository.ConsultarPorCorreo(correo);
        }

        public List<UsuarioDTO> ConsultarGeneralDTO()
        {
            return _usuarioRepository.ConsultarGeneralDTO();
        }

        public Usuario Agregar(Usuario usuario)
        {
            return _usuarioRepository.Agregar(usuario);
        }

        public Usuario Editar(Usuario usuario)
        {
            _usuarioRepository.Editar(usuario);
            return usuario;
        }

        public void Eliminar(int idUsuario)
        {

            _usuarioRepository.Eliminar(ConsultarPorId(idUsuario));
        }
    }
}
