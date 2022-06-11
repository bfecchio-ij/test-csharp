using Candidatos.Domain.Interfaces.Repositories;
using Candidatos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidatos.Infra.Data.Repositories
{
    public class RepositoryBase<entity>: IRepositoryBase<entity> where entity: class
    {
        private readonly JobContext _context = new JobContext();

        public void Add(entity obj)
        {
            _context.Set<entity>().Add(obj);
            _context.SaveChanges();
        }

        public async Task AddAsync(entity obj)
        {
            await _context.Set<entity>().AddAsync(obj);
        }

        public async Task<IEnumerable<entity>> GetAllAsync()
        {
            return await _context.Set<entity>().ToListAsync();
        }

        public async Task<entity> GetByIdAsync(int id)
        {
            return await _context.Set<entity>().FindAsync(id);
        }

        public async Task RemoveAsync(entity obj)
        {
            _context.Set<entity>().Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(entity obj)
        {
            _context.Entry(obj).Property("ModifyDate").CurrentValue = DateTime.UtcNow;
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
