using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Domain.Entities
{
    public partial class MunicipioEntity
    {
        public int IdMunicipio { get; set; }

        public string? NombreMunicipio { get; set; }

        public string? LatitudMunicipio { get; set; }

        public string? LongitudMunicipio { get; set; }

        public virtual ICollection<InstitucionEntity> Institucion { get; set; } = new List<InstitucionEntity>();
    }
}
