using System;
using System.Collections.Generic;

namespace DotacionBack.Infrastructure.Persistence.Models;

public partial class Institucion
{
    public int IdInstitucion { get; set; }

    public string NombreInstitucion { get; set; } = null!;

    public string CodigodaneInstitucion { get; set; } = null!;

    public string CalendarioInstitucion { get; set; } = null!;

    public int FkIdMunicipio { get; set; }

    public virtual Municipio FkIdMunicipioNavigation { get; set; } = null!;

    public virtual ICollection<Sede> Sede { get; set; } = new List<Sede>();
}
