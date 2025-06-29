using System;
using System.Collections.Generic;

namespace DotacionBack.Infrastructure.Persistence.Models;

public partial class Sede
{
    public int IdSede { get; set; }

    public string NombreSede { get; set; } = null!;

    public string CodigodaneSede { get; set; } = null!;

    public string ZonaSede { get; set; } = null!;

    public string DireccionSede { get; set; } = null!;

    public string LongitudSede { get; set; } = null!;

    public string LatitudSede { get; set; } = null!;

    public int FkIdInstitucion { get; set; }

    public virtual ICollection<Dotacion> Dotacion { get; set; } = new List<Dotacion>();

    public virtual Institucion FkIdInstitucionNavigation { get; set; } = null!;
}
