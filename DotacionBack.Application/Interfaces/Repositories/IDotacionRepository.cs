using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotacionBack.Domain.Entities;


namespace DotacionBack.Application.Interfaces.Repositories
{
    public interface IDotacionRepository
    {
        Task<IEnumerable<DotacionEntity>> GetAllAsync();
        Task<DotacionEntity?> GetByIdAsync(int id);
        Task AddAsync(DotacionEntity dotacion);
    }
}
