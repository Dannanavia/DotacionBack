using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Application.DTOs
{
    public class MunicipioDto
    {
        public string NombreMunicipio { get; set; } = null!;
        public string LatitudMunicipio { get; set; } = null!;
        public string LongitudMunicipio { get; set; } = null!;
    }

}
