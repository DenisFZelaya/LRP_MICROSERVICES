
using Agencies.Infraestructura.Context;
using Agencies.Infraestructura.Data.Entities;
using Agencies.Infraestructura.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Agencies.Infraestructura.Data.RepositoriesImplementations
{
    public class AgencyImplementations : IAgencyRepository
    {
        private readonly AGENCIESContext _dbContext;

        public AgencyImplementations(AGENCIESContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Agencias>> GetAllAsync()
        {
            return await _dbContext.Agencias.ToListAsync();
        }

        public async Task<Agencias> GetByIdAsync(int id)
        {
            return await _dbContext.Agencias.FindAsync(id);
        }

        public async Task<Agencias> AddAsync(Agencias agency)
        {
            await _dbContext.Agencias.AddAsync(agency);
            await _dbContext.SaveChangesAsync();
            return agency;
        }

        public async Task UpdateAsync(Agencias agency)
        {
            _dbContext.Entry(agency).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var agency = await GetByIdAsync(id);
            _dbContext.Agencias.Remove(agency);
            await _dbContext.SaveChangesAsync();
        }
    }
}
