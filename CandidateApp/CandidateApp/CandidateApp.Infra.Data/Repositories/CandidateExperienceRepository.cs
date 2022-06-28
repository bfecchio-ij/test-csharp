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
    public class CandidateExperienceRepository : Repository<CandidateExperience>, ICandidateExperienceRepository
    {
        private readonly CandidateDBContext _context;

        public CandidateExperienceRepository(CandidateDBContext context) : base(context)
        {
            _context = context;
        }

        public CandidateExperience Get(Guid id)
        {
            return _context.Set<CandidateExperience>().AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<CandidateExperience> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
