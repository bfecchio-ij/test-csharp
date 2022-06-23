using CQRS.INFO.Models.Data;
using CQRS.INFO.Models.Entities;
using CQRS.INFO.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.INFO.Services
{
    public class CandidateServices : ICandidateServices
    {
        private readonly ApplicationContext _context;
        public CandidateServices(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Candidate> CreateCandidate(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();
            return candidate;
        }

        public async Task<int> DeleteCandidate(Candidate candidate)
        {
            _context.Candidates.Remove(candidate);
            return await _context.SaveChangesAsync();
        }

        public async Task<Candidate> GetCandidateById(int id)
        {
            return await _context.Candidates
           .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Candidate>> GetListOfCandidates()
        {
            return await _context.Candidates
           .ToListAsync();
        }

        public async Task<int> UpdateCandidate(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            return await _context.SaveChangesAsync();
        }
        public async Task<Candidate> GetEmailChecked(string email)
        {
            return await _context.Candidates.FirstOrDefaultAsync(_ => _.Email == email);

        }

    }
}
