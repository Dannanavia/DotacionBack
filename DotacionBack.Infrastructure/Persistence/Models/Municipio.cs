using System;
using System.Collections.Generic;

namespace DotacionBack.Infrastructure.Persistence.Models;

public partial class Municipio
{
    public int IdMunicipio { get; set; }

    public string? NombreMunicipio { get; set; }

    public string? LatitudMunicipio { get; set; }

    public string? LongitudMunicipio { get; set; }

    public virtual ICollection<Institucion> Institucion { get; set; } = new List<Institucion>();
}
