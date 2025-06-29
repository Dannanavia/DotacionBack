using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Application.DTOs
{
    public class InstitucionDto
    {
        public string NombreInstitucion { get; set; } = null!;
        public string CalendarioInstitucion { get; set; } = null!;
        public string CodigodaneInstitucion { get; set; } = null!;
        public int FkIdMunicipio { get; set; }
    }

}
