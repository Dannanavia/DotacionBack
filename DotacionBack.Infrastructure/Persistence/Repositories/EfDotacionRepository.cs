using DotacionBack.Application.Interfaces.Repositories;
using DotacionBack.Domain.Entities;
using DotacionBack.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DotacionBack.Infrastructure.Persistence.Repositories
{
    public class EfDotacionRepository : IDotacionRepository
    {
        private readonly DotacionDbContext _context;

        public EfDotacionRepository(DotacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DotacionEntity>> GetAllAsync()
        {
            return await _context.Dotacion
                .Select(d => new DotacionEntity
                {
                    IdDotacion = d.IdDotacion,
                    CantidadDotacion = d.CantidadDotacion,
                    FkIdArticulo = d.FkIdArticulo,
                    FkIdSede = d.FkIdSede,
                    FkIdTipodotacion = d.FkIdTipodotacion
                })
                .ToListAsync();
        }

        public async Task<DotacionEntity?> GetByIdAsync(int id)
        {
            var d = await _context.Dotacion.FindAsync(id);
            return d == null ? null : new DotacionEntity
            {
                IdDotacion = d.IdDotacion,
                CantidadDotacion = d.CantidadDotacion,
                FkIdArticulo = d.FkIdArticulo,
                FkIdSede = d.FkIdSede,
                FkIdTipodotacion = d.FkIdTipodotacion
            };
        }

        public async Task AddAsync(DotacionEntity dotacion)
        {
            var efModel = new Dotacion
            {
                IdDotacion = dotacion.IdDotacion,
                CantidadDotacion = dotacion.CantidadDotacion,
                FkIdArticulo = dotacion.FkIdArticulo,
                FkIdSede = dotacion.FkIdSede,
                FkIdTipodotacion = dotacion.FkIdTipodotacion
            };

            await _context.Dotacion.AddAsync(efModel);
            await _context.SaveChangesAsync();
        }
    }
}
