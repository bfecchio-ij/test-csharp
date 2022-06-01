using Microsoft.EntityFrameworkCore;
using test_CSharp.Interfaces.Repositories;
using test_CSharp.Models;

namespace test_CSharp.Repositories
{
    public class CandidateExperienceRepository : ICandidateExperienceRepository
    {
        private readonly DataContext _context;

        public CandidateExperienceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync() { await _context.SaveChangesAsync(); }

        public Task AddExperience(CandidateExperience experience)
        {
            _context.CandidateExperiences.Add(experience);
            return Task.CompletedTask;
        }

        public async Task<List<CandidateExperience>> GetExperiencesAsync(int idCandidate)
        {
            return await _context.CandidateExperiences.Where(e => e.IdCandidate == idCandidate).ToListAsync();
        }


    }
}
