using Microsoft.EntityFrameworkCore;
using test_CSharp.Data;
using test_CSharp.Interfaces.Repositories;
using test_CSharp.Models;

namespace test_CSharp.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {

        private static List<Candidate> _candidates = new()
        {
            new Candidate
            {
                Email = "Marcello@email.com",
                IdCandidate = 1,
                InsertDate = DateTime.Now,
                ModifyDate = null,
                Name = "Marcello",
                Surname = "Bronzatti"
            }
        };
        private readonly DataContext _context;
        public CandidateRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Candidate>> GetCandidatesAsync()
        {
            return await _context.Candidates.ToListAsync();
        }
    }
}
