using SICPC_API.Entities.Models;
using SicpcAPI.Entities.Models.Seguridad;
using SicpcAPI.Helpers;

namespace SICPC_API.Services.Seguridad
{
    public class LoginService
    {
        private readonly UsuarioService _usuarioService;

        public LoginService(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Usuario Login(LoginRequest loginRequest)
        {
            var usuario = _usuarioService.ConsultarPorCorreo(loginRequest.Correo);
            if (usuario == null)
            {
                throw new SicpcException("Usuario no encontrado");
            }

            if (usuario.Contrasena != loginRequest.Contrasena)
            {
                throw new SicpcException("Contraseña incorrecta");
            }

            return usuario;
        }

    }
}
