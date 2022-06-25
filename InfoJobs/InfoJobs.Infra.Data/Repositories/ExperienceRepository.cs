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

        public void Delete(CandidateExperience exp)
        {
            _ctx.Experiences.Remove(SearchById(exp.Id));
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

        public CandidateExperience SearchById(Guid? id)
        {
            return _ctx.Experiences.FirstOrDefault(x => x.Id == id);
        }

        public List<CandidateExperience> SearchExperienceByCandidate(Guid? idCandidate)
        {
            var experiences = _ctx.Experiences.Where(x => x.IdCandidate == idCandidate).ToList();

            return experiences;
        }
    }
}
