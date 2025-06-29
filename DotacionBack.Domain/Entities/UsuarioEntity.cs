using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Domain.Entities
{
    public class UsuarioEntity
    {
        public int IdUsuario { get; set; }
        public string CorreoUsuario { get; set; } = null!;
        public string ContraseniaUsuario { get; set; } = null!;
    }
}
