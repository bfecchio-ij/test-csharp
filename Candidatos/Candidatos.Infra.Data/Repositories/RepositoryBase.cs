using Candidatos.Domain.Interfaces.Repositories;
using Candidatos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<entity> GetAll()
        {
            return _context.Set<entity>().ToList();
        }

        public entity GetById(int id)
        {
            return _context.Set<entity>().Find(id);
        }

        public void Remove(entity obj)
        {
            _context.Set<entity>().Remove(obj);
            _context.SaveChanges();
        }

        public void Update(entity obj)
        {
            _context.Entry(obj).Property("ModifyDate").CurrentValue = DateTime.UtcNow;
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
