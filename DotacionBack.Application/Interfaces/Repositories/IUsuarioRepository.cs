using DotacionBack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Application.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<UsuarioEntity?> GetByCredentialsAsync(string correo, string contrasenia);
    }
}
