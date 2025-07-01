using DotacionBack.Application.DTOs;
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
    public class EfSedeRepository : ISedeRepository
    {
        private readonly DotacionDbContext _context;

        public EfSedeRepository(DotacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SedeEntity>> GetAllAsync()
        {
            return await _context.Sede
                .Select(s => new SedeEntity
                {
                    IdSede = s.IdSede,
                    NombreSede = s.NombreSede,
                    CodigodaneSede = s.CodigodaneSede,
                    DireccionSede = s.DireccionSede,
                    LatitudSede = s.LatitudSede,
                    LongitudSede = s.LongitudSede,
                    ZonaSede = s.ZonaSede,
                    FkIdInstitucion = s.FkIdInstitucion
                })
                .ToListAsync();
        }

        public async Task<SedeEntity?> GetByIdAsync(int id)
        {
            var s = await _context.Sede.FindAsync(id);
            return s is null ? null : new SedeEntity
            {
                IdSede = s.IdSede,
                NombreSede = s.NombreSede,
                CodigodaneSede = s.CodigodaneSede,
                DireccionSede = s.DireccionSede,
                LatitudSede = s.LatitudSede,
                LongitudSede = s.LongitudSede,
                ZonaSede = s.ZonaSede,
                FkIdInstitucion = s.FkIdInstitucion
            };
        }

        public async Task AddAsync(SedeEntity sede)
        {
            var entity = new Sede
            {
                NombreSede = sede.NombreSede,
                CodigodaneSede = sede.CodigodaneSede,
                DireccionSede = sede.DireccionSede,
                LatitudSede = sede.LatitudSede,
                LongitudSede = sede.LongitudSede,
                ZonaSede = sede.ZonaSede,
                FkIdInstitucion = sede.FkIdInstitucion
            };

            await _context.Sede.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SedeDotacionResumenDto>> GetResumenDotacionBySedeId(int institucionId)
        {
            return await _context.Sede
                .Where(s => s.FkIdInstitucion == institucionId)
                .Select(s => new SedeDotacionResumenDto
                {
                    IdSede = s.IdSede,
                    NombreSede = s.NombreSede,
                    DireccionSede = s.DireccionSede,
                    ZonaSede = s.ZonaSede,

                    CantidadResidenciasEscolares = s.Dotacion
                        .Where(d => d.FkIdTipodotacionNavigation.NombreTipodotacion == "Dotacion de residencias escolares")
                        .Sum(d => d.CantidadDotacion),

                    CantidadDotacionesAulas = s.Dotacion
                        .Where(d => d.FkIdTipodotacionNavigation.NombreTipodotacion == "Dotaciones de aulas")
                        .Sum(d => d.CantidadDotacion)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<DotacionPorSedeDto>> GetDotacionBySedeId(int sedeId)
        {
            return await _context.Dotacion
                .Where(d => d.FkIdSede == sedeId)
                .Select(d => new DotacionPorSedeDto
                {
                    IdArticulo = d.FkIdArticuloNavigation.IdArticulo,
                    DescripcionArticulo = d.FkIdArticuloNavigation.DescripcionArticulo,
                    TipoDotacion = d.FkIdTipodotacionNavigation.NombreTipodotacion,
                    Cantidad = d.CantidadDotacion
                })
                .ToListAsync();
        }


    }

}
