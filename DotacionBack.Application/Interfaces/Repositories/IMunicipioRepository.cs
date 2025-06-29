using DotacionBack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Application.Interfaces.Repositories
{
    public interface IMunicipioRepository
    {
        Task<IEnumerable<MunicipioEntity>> GetAllAsync();
        Task<MunicipioEntity?> GetByIdAsync(int id);
        Task AddAsync(MunicipioEntity municipio);
    }
}
