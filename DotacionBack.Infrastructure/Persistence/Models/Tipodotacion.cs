using System;
using System.Collections.Generic;

namespace DotacionBack.Infrastructure.Persistence.Models;

public partial class Tipodotacion
{
    public int IdTipodotacion { get; set; }

    public string NombreTipodotacion { get; set; } = null!;

    public virtual ICollection<Dotacion> Dotacion { get; set; } = new List<Dotacion>();
}
