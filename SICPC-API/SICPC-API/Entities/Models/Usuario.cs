using System;
using System.Collections.Generic;

namespace SICPC_API.Entities.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string TelefonoMovil { get; set; } = null!;

    public bool Habilitado { get; set; }
}
