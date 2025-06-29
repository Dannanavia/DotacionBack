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
    public class EfMunicipioRepository : IMunicipioRepository
    {
        private readonly DotacionDbContext _context;

        public EfMunicipioRepository(DotacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MunicipioEntity>> GetAllAsync()
        {
            return await _context.Municipio
                .Select(m => new MunicipioEntity
                {
                    IdMunicipio = m.IdMunicipio,
                    NombreMunicipio = m.NombreMunicipio,
                    LatitudMunicipio = m.LatitudMunicipio,
                    LongitudMunicipio = m.LongitudMunicipio
                })
                .ToListAsync();
        }

        public async Task<MunicipioEntity?> GetByIdAsync(int id)
        {
            var m = await _context.Municipio.FindAsync(id);
            return m is null ? null : new MunicipioEntity
            {
                IdMunicipio = m.IdMunicipio,
                NombreMunicipio = m.NombreMunicipio,
                LatitudMunicipio = m.LatitudMunicipio,
                LongitudMunicipio = m.LongitudMunicipio
            };
        }

        public async Task AddAsync(MunicipioEntity municipio)
        {
            var entity = new Municipio
            {
                NombreMunicipio = municipio.NombreMunicipio,
                LatitudMunicipio = municipio.LatitudMunicipio,
                LongitudMunicipio = municipio.LongitudMunicipio
            };

            await _context.Municipio.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }

}
