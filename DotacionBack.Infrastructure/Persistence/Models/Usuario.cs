using System;
using System.Collections.Generic;

namespace DotacionBack.Infrastructure.Persistence.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? CorreoUsuario { get; set; }

    public string? ContraseniaUsuario { get; set; }
}
