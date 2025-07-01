using DotacionBack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Application.Interfaces.Repositories
{
    public interface IInstitucionRepository
    {
        Task<IEnumerable<InstitucionEntity>> GetAllAsync();
        Task<InstitucionEntity?> GetByIdAsync(int id);
        Task<IEnumerable<InstitucionEntity>> GetAllByMunicipioId(int MunicipioId);
        Task AddAsync(InstitucionEntity institucion);
    }
}
