using System;
using System.Collections.Generic;

namespace SICPC_API.Entities.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string DescripcionCorta { get; set; } = null!;

    public string? DescripcionLarga { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? Icon { get; set; }
}
