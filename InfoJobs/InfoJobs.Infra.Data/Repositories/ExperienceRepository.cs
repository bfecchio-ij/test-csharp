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
    public class ExperienceRepository : IExperienceRepository
    {
        // Dependency Injection:
        private readonly InfoJobsContext _ctx;

        public ExperienceRepository(InfoJobsContext ctx)
        {
            _ctx = ctx;
        }


        // Commands:
        public void Add(CandidateExperience exp)
        {
            _ctx.Experiences.Add(exp);
            _ctx.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _ctx.Experiences.Remove(SearchById(id));
            _ctx.SaveChanges();
        }

        public void Update(CandidateExperience exp)
        {
            _ctx.Entry(exp).State = EntityState.Modified;
            _ctx.SaveChanges();
        }



        // Queries:
        public IEnumerable<CandidateExperience> List()
        {
            return _ctx.Experiences
                .AsNoTracking()
                .ToList();
        }

        public CandidateExperience SearchById(Guid id)
        {
            return _ctx.Experiences
                .FirstOrDefault(x => x.Id == id);
        }

        public CandidateExperience SearchByCandidateId(Guid idCandidate)
        {
            return _ctx.Experiences
                .FirstOrDefault(e => e.Candidates.Id == idCandidate);
        }
    }
}
