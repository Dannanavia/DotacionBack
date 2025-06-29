using System;
using System.Collections.Generic;

namespace DotacionBack.Infrastructure.Persistence.Models;

public partial class SeguimientoDotacion
{
    public int IdSeguimiento { get; set; }

    public int FkIdDotacion { get; set; }

    public int FkIdEstado { get; set; }

    public int? CantidadRecibida { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Dotacion FkIdDotacionNavigation { get; set; } = null!;

    public virtual EstadoDotacion FkIdEstadoNavigation { get; set; } = null!;

    public virtual ICollection<SeguimientoObservacion> SeguimientoObservacion { get; set; } = new List<SeguimientoObservacion>();
}
