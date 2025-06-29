using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Application.DTOs
{
    public class LoginDto
    {
        public string CorreoUsuario { get; set; } = null!;
        public string ContraseniaUsuario { get; set; } = null!;
    }
}
