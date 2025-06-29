using DotacionBack.Application.Interfaces.Repositories;
using DotacionBack.Domain.Entities;
using DotacionBack.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Infrastructure.Persistence.Repositories
{
    public class EfUsuarioRepository : IUsuarioRepository
    {
        private readonly DotacionDbContext _context;

        public EfUsuarioRepository(DotacionDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioEntity?> GetByCredentialsAsync(string correo, string contrasenia)
        {
            var user = await _context.Usuario
                .FirstOrDefaultAsync(u => u.CorreoUsuario == correo && u.ContraseniaUsuario == contrasenia);

            if (user is null) return null;

            return new UsuarioEntity
            {
                IdUsuario = user.IdUsuario,
                CorreoUsuario = user.CorreoUsuario!,
                ContraseniaUsuario = user.ContraseniaUsuario!
            };
        }
    }
}
