using System;
using System.Collections.Generic;

namespace SICPC_API.Entities.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Empresa { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Mensaje { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }
}
