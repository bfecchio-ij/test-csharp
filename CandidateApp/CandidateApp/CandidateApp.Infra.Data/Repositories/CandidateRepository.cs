using CandidateApp.Domain.Entities;
using CandidateApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateApp.Infra.Data.Repositories
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        private readonly CandidateDBContext context;

        public CandidateRepository(CandidateDBContext context) : base(context)
        {
        }

        public Candidate Get(Guid id)
        {

            return Find(c => c.Id == id);
        }

        public IEnumerable<Candidate> GetAll()
        {
            return Query(c => c.Id != Guid.Empty).ToList();
        }

        public void Delete(Candidate entity)
        {
            context.Set<Candidate>().Remove(entity);
        }
    }
}
