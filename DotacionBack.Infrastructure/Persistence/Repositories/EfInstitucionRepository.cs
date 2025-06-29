using DotacionBack.Application.Interfaces.Repositories;
using DotacionBack.Domain.Entities;
using DotacionBack.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotacionBack.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DotacionBack.Infrastructure.Persistence.Repositories
{
    public class EfInstitucionRepository : IInstitucionRepository
    {
        private readonly DotacionDbContext _context;

        public EfInstitucionRepository(DotacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InstitucionEntity>> GetAllAsync()
        {
            return await _context.Institucion
                .Include(x => x.Sede) // ← incluimos las sedes
                .Select(x => new InstitucionEntity
                {
                    IdInstitucion = x.IdInstitucion,
                    NombreInstitucion = x.NombreInstitucion,
                    CalendarioInstitucion = x.CalendarioInstitucion,
                    CodigodaneInstitucion = x.CodigodaneInstitucion,
                    FkIdMunicipio = x.FkIdMunicipio,
                    Sede = x.Sede.Select(s => new SedeEntity
                    {
                        IdSede = s.IdSede,
                        NombreSede = s.NombreSede,
                        CodigodaneSede = s.CodigodaneSede,
                        DireccionSede = s.DireccionSede,
                        LatitudSede = s.LatitudSede,
                        LongitudSede = s.LongitudSede,
                        ZonaSede = s.ZonaSede,
                        FkIdInstitucion = s.FkIdInstitucion
                    }).ToList()
                })
                .ToListAsync();
        }


        public async Task<InstitucionEntity?> GetByIdAsync(int id)
        {
            var institucion = await _context.Institucion
                .Include(x => x.Sede)
                .FirstOrDefaultAsync(x => x.IdInstitucion == id);

            if (institucion is null)
                return null;

            return new InstitucionEntity
            {
                IdInstitucion = institucion.IdInstitucion,
                NombreInstitucion = institucion.NombreInstitucion,
                CalendarioInstitucion = institucion.CalendarioInstitucion,
                CodigodaneInstitucion = institucion.CodigodaneInstitucion,
                FkIdMunicipio = institucion.FkIdMunicipio,
                Sede = institucion.Sede.Select(s => new SedeEntity
                {
                    IdSede = s.IdSede,
                    NombreSede = s.NombreSede,
                    CodigodaneSede = s.CodigodaneSede,
                    DireccionSede = s.DireccionSede,
                    LatitudSede = s.LatitudSede,
                    LongitudSede = s.LongitudSede,
                    ZonaSede = s.ZonaSede,
                    FkIdInstitucion = s.FkIdInstitucion
                }).ToList()
            };
        }


        public async Task AddAsync(InstitucionEntity institucion)
        {
            var entity = new Institucion
            {
                NombreInstitucion = institucion.NombreInstitucion,
                CalendarioInstitucion = institucion.CalendarioInstitucion,
                CodigodaneInstitucion = institucion.CodigodaneInstitucion,
                FkIdMunicipio = institucion.FkIdMunicipio
            };

            await _context.Institucion.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
