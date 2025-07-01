using DotacionBack.Application.DTOs;
using DotacionBack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Application.Interfaces.Repositories
{
    public interface ISedeRepository
    {
        Task<IEnumerable<SedeEntity>> GetAllAsync();
        Task<SedeEntity?> GetByIdAsync(int id);
        Task<IEnumerable<SedeDotacionResumenDto>> GetResumenDotacionBySedeId(int InstitucionId);
        Task<IEnumerable<DotacionPorSedeDto>> GetDotacionBySedeId(int sedeId);
        Task AddAsync(SedeEntity sede);
    }
}
