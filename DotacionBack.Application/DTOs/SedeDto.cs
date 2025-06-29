using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Application.DTOs
{
    public class SedeDto
    {
        public string NombreSede { get; set; } = null!;
        public string CodigodaneSede { get; set; } = null!;
        public string DireccionSede { get; set; } = null!;
        public string LatitudSede { get; set; } = null!;
        public string LongitudSede { get; set; } = null!;
        public string ZonaSede { get; set; } = null!;
        public int FkIdInstitucion { get; set; }
    }

}
