using InfoJobs.Domain.Entities;
using InfoJobs.Domain.Interfaces;
using InfoJobs.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoJobs.Infra.Data.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        // Dependency Injection:
        private readonly InfoJobsContext _ctx;

        public CandidateRepository(InfoJobsContext ctx)
        {
            _ctx = ctx;
        }


        // Commands:
        public void Add(Candidate candidate)
        {
            _ctx.Candidates.Add(candidate);
            _ctx.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _ctx.Candidates.Remove(SearchById(id));
            _ctx.SaveChanges();
        }

        public void Update(Candidate candidate)
        {
            _ctx.Entry(candidate).State = EntityState.Modified;
            _ctx.SaveChanges();
        }



        // Queries:
        public IEnumerable<Candidate> List()
        {
            return _ctx.Candidates
                .AsNoTracking()
                .ToList();
        }

        public Candidate SearchById(Guid id)
        {
            return _ctx.Candidates
                .Include(x => x.Experiences)
                .FirstOrDefault(x => x.Id == id);
        }

        public Candidate SearchByEmail(string email)
        {
            return _ctx.Candidates
                .Include(x => x.Experiences)
                .FirstOrDefault(x => x.Email == email);
        }
    }
}
