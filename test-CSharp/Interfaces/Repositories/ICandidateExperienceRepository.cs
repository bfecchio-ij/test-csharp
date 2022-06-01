using test_CSharp.Models;

namespace test_CSharp.Interfaces.Repositories
{
    public interface ICandidateExperienceRepository
    {
        Task SaveChangesAsync();
        Task<List<CandidateExperience>> GetExperiencesAsync(int idCandidate);
        Task<CandidateExperience> GetExperienceByIdAsync(int idCandidate);
        Task<CandidateExperience> GetExperienceToUpdateAsync(int idExperience, int idCandidate);
        Task AddExperience(CandidateExperience experience);
        Task UpdateExperienceAsync(CandidateExperience experience);
        Task RemoveExperienceAsync(CandidateExperience experience);

    }
}
