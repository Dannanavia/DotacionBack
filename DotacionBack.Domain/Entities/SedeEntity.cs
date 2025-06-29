using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Domain.Entities
{
    public partial class SedeEntity
    {
        public int IdSede { get; set; }

        public string NombreSede { get; set; } = null!;

        public string CodigodaneSede { get; set; } = null!;

        public string ZonaSede { get; set; } = null!;

        public string DireccionSede { get; set; } = null!;

        public string LongitudSede { get; set; } = null!;

        public string LatitudSede { get; set; } = null!;

        public int FkIdInstitucion { get; set; }

        public virtual ICollection<DotacionEntity> Dotacion { get; set; } = new List<DotacionEntity>();

        public virtual InstitucionEntity FkIdInstitucionNavigation { get; set; } = null!;
    }
}
