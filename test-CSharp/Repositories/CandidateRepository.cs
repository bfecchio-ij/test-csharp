using Microsoft.EntityFrameworkCore;
using test_CSharp.Data;
using test_CSharp.Interfaces.Repositories;
using test_CSharp.Models;

namespace test_CSharp.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {

        private readonly DataContext _context;
        public CandidateRepository(DataContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Candidate>> GetCandidatesAsync()
        {
            return await _context.Candidates.ToListAsync();
        }
        public async Task<Candidate> GetCandidateByIdAsync(int id)
        {
            return await _context.Candidates.FirstOrDefaultAsync(c => c.IdCandidate == id);
        }

        public async Task AddCandidate(Candidate candidate)
        {
            _context.Add(candidate);
            return;

        }

        public async Task RemoveCandidate(Candidate candidate)
        {
            _context.Remove(candidate);
            return;
        }
    }
}
