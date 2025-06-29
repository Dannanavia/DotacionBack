using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Domain.Entities
{
    public class DotacionEntity
    {
        public int IdDotacion { get; set; }
        public int CantidadDotacion { get; set; }
        public int FkIdArticulo { get; set; }
        public int FkIdSede { get; set; }
        public int FkIdTipodotacion { get; set; }
    }
}
