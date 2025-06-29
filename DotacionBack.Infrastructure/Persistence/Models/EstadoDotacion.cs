using System;
using System.Collections.Generic;

namespace DotacionBack.Infrastructure.Persistence.Models;

public partial class EstadoDotacion
{
    public int IdEstadoDotacion { get; set; }

    public string NombreEstado { get; set; } = null!;

    public virtual ICollection<Dotacion> Dotacion { get; set; } = new List<Dotacion>();

    public virtual ICollection<SeguimientoDotacion> SeguimientoDotacion { get; set; } = new List<SeguimientoDotacion>();
}
