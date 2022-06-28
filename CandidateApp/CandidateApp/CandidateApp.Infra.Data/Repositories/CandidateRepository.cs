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
        private readonly CandidateDBContext _context;

        public CandidateRepository(CandidateDBContext context) : base(context)
        {
            _context = context;
        }



        public Candidate Get(Guid id)
        {

            return _context.Set<Candidate>().AsNoTracking().Where(c => c.Id == id).Include(x => x.CandidateExperiences).FirstOrDefault();
        }

        public IEnumerable<Candidate> GetAll()
        {
            return _context.Set<Candidate>().AsNoTracking().Include(x => x.CandidateExperiences).ToList();
        }

    }
}
