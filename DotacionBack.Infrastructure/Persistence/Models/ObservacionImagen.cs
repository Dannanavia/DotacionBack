using System;
using System.Collections.Generic;

namespace DotacionBack.Infrastructure.Persistence.Models;

public partial class ObservacionImagen
{
    public int IdImagen { get; set; }

    public int FkIdObservacion { get; set; }

    public string UrlImagen { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public virtual SeguimientoObservacion FkIdObservacionNavigation { get; set; } = null!;
}
