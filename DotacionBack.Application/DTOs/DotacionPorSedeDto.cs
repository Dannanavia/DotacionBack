using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Application.DTOs
{
    public class DotacionPorSedeDto
    {
        public int IdArticulo { get; set; }
        public string DescripcionArticulo { get; set; } = null!;
        public string TipoDotacion { get; set; } = null!;
        public int Cantidad { get; set; }
    }
}
