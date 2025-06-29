using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Domain.Entities
{
    public partial class InstitucionEntity
    {
        public int IdInstitucion { get; set; }

        public string NombreInstitucion { get; set; } = null!;

        public string CodigodaneInstitucion { get; set; } = null!;

        public string CalendarioInstitucion { get; set; } = null!;

        public int FkIdMunicipio { get; set; }

        public virtual MunicipioEntity FkIdMunicipioNavigation { get; set; } = null!;

        public virtual ICollection<SedeEntity> Sede { get; set; } = new List<SedeEntity>();
    }
}
