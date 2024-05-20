using SendGrid;
using SendGrid.Helpers.Mail;
using SICPC_API.Entities.Models;
using SicpcAPI.Entities.DTOs.Seguridad;
using SicpcAPI.Repositorys.Seguridad;
using System.Net.Mail;

namespace SICPC_API.Services.Seguridad
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(
            ClienteRepository clienteRepository
            )
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> ConsultarGeneral()
        {
            return _clienteRepository.ConsultarGeneral();
        }

        public Cliente ConsultarPorId(int idCliente)
        {
            return _clienteRepository.ConsultarPorId(idCliente);
        }

        public async Task<Cliente> Agregar(Cliente cliente)
        {
            await EnviarCorreoNuevoCliente(cliente);
            return _clienteRepository.Agregar(cliente);
        }

        public Cliente Editar(Cliente cliente)
        {
            _clienteRepository.Editar(cliente);
            return cliente;
        }

        public void Eliminar(int idCliente)
        {

            _clienteRepository.Eliminar(ConsultarPorId(idCliente));
        }

        private async Task<IAsyncResult> EnviarCorreoNuevoCliente(Cliente cliente)
        {
            var apiKey ="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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("osvaldo.ortega159@gmail.com", "Notificación SICPC Web");
            var subject = $"SICPC-WEB: {cliente.Empresa}";
            var to = new EmailAddress("osvaldo.ortega159@gmail.com", "Administrador");
            var plainTextContent = $"";
            var htmlContent = $@"
<!DOCTYPE html>
<html lang='es'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <style>
        body {{
            font-family: Arial, sans-serif;
            line-height: 1.6;
            color: #333;
            padding: 20px;
            background-color: #f9f9f9;
        }}
        .container {{
            max-width: 600px;
            margin: auto;
            background: #fff;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 5px;
        }}
        .header {{
            text-align: center;
            border-bottom: 1px solid #ddd;
            margin-bottom: 20px;
            padding-bottom: 10px;
        }}
        .footer {{
            text-align: center;
            border-top: 1px solid #ddd;
            margin-top: 20px;
            padding-top: 10px;
            color: #777;
        }}
        .content {{
            margin-bottom: 20px;
        }}
        .content p {{
            margin: 10px 0;
        }}
        .content strong {{
            color: #000;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h2>Nuevo mensaje desde SICPC</h2>
        </div>
        <div class='content'>
            <p>Has recibido un nuevo mensaje desde la página de SICPC:</p>
            <p><strong>Nombre Completo del Cliente:</strong> {cliente.NombreCompleto}</p>
            <p><strong>Correo Electrónico:</strong> {cliente.Correo}</p>
            <p><strong>Empresa:</strong> {cliente.Empresa}</p>
            <p><strong>Mensaje:</strong> {cliente.Mensaje}</p>
            <p><strong>Teléfono:</strong> {cliente.Telefono}</p>
        </div>
        <div class='footer'>
            <p>Este mensaje fue enviado desde el formulario de contacto de SICPC.</p>
            <p>Atentamente, <strong>{cliente.NombreCompleto}</strong></p>
        </div>
    </div>
</body>
</html>
";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return Task.CompletedTask;
        }
    }
}
