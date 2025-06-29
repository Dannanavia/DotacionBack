using System;
using System.Collections.Generic;

namespace DotacionBack.Infrastructure.Persistence.Models;

public partial class Articulo
{
    public int IdArticulo { get; set; }

    public string DescripcionArticulo { get; set; } = null!;

    public virtual ICollection<Dotacion> Dotacion { get; set; } = new List<Dotacion>();
}
