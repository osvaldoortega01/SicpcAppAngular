using SICPC_API.Entities.Models;
using SicpcAPI.Entities.Models;

namespace SicpcAPI.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Content-Type", "text/plain");
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static string ObtenerNombreCompleto(this Usuario usuario)
        {
            return "";
            //if (usuario == null)
            //{
            //    return string.Empty;
            //}

            //return (usuario.Nombre + " " + usuario.ApellidoPaterno + " " + usuario.ApellidoMaterno).Trim();
        }
    }
}
