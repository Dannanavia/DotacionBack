using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Application.DTOs
{
    public class SedeDotacionResumenDto
    {
        public int IdSede { get; set; }
        public string NombreSede { get; set; } = null!;
        public string DireccionSede { get; set; } = null!;
        public string ZonaSede { get; set; } = null!;

        public int CantidadResidenciasEscolares { get; set; }
        public int CantidadDotacionesAulas { get; set; }
    }
}
