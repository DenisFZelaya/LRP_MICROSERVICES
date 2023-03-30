using Agencies.Infraestructura.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencies.Infraestructura.Interfaces
{
    public interface IAgencyRepository
    {
        Task<IEnumerable<Agencias>> GetAllAsync();
        Task<Agencias> GetByIdAsync(int id);
        Task<Agencias> AddAsync(Agencias agency);
        Task UpdateAsync(Agencias agency);
        Task DeleteAsync(int id);
    }
}
