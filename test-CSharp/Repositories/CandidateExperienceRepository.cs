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
        public async Task<CandidateExperience> GetExperienceToUpdateAsync(int idExperience, int idCandidate)
        {
            return await _context.CandidateExperiences.Where(e => e.IdCandidateExperience == idExperience && e.IdCandidate == idCandidate).FirstOrDefaultAsync();
        }

        public Task UpdateExperienceAsync(CandidateExperience experience)
        {
            _context.CandidateExperiences.Update(experience);
            return Task.CompletedTask;
        }

        public Task RemoveExperienceAsync(CandidateExperience experience)
        {
            _context.CandidateExperiences.Remove(experience);
            return Task.CompletedTask;
        }

        public async Task<CandidateExperience> GetExperienceByIdAsync(int idExperience)
        {
            return await _context.CandidateExperiences.FirstOrDefaultAsync(x => x.IdCandidateExperience == idExperience);
        }
    }
}
