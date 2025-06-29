using System;
using System.Collections.Generic;

namespace DotacionBack.Infrastructure.Persistence.Models;

public partial class SeguimientoObservacion
{
    public int IdObservacion { get; set; }

    public int FkIdSeguimiento { get; set; }

    public string Texto { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public virtual SeguimientoDotacion FkIdSeguimientoNavigation { get; set; } = null!;

    public virtual ICollection<ObservacionImagen> ObservacionImagen { get; set; } = new List<ObservacionImagen>();
}
