using test_CSharp.Models;

namespace test_CSharp.Interfaces.Repositories
{
    public interface ICandidateExperienceRepository
    {
        Task<List<CandidateExperience>> GetExperiencesAsync(int idCandidate);
        Task AddExperience(CandidateExperience experience);
        Task SaveChangesAsync();
    }
}
