using System;
using System.Collections.Generic;

namespace DotacionBack.Infrastructure.Persistence.Models;

public partial class Dotacion
{
    public int IdDotacion { get; set; }

    public int CantidadDotacion { get; set; }

    public int FkIdArticulo { get; set; }

    public int FkIdSede { get; set; }

    public int FkIdTipodotacion { get; set; }

    public int? FkIdEstadoActual { get; set; }

    public virtual Articulo FkIdArticuloNavigation { get; set; } = null!;

    public virtual EstadoDotacion? FkIdEstadoActualNavigation { get; set; }

    public virtual Sede FkIdSedeNavigation { get; set; } = null!;

    public virtual Tipodotacion FkIdTipodotacionNavigation { get; set; } = null!;

    public virtual ICollection<SeguimientoDotacion> SeguimientoDotacion { get; set; } = new List<SeguimientoDotacion>();
}
