using test_CSharp.Models;
using test_CSharp.Models.DTO;

namespace test_CSharp.Interfaces.Services
{
    public interface ICandidateExperienceService
    {
        Task<List<CandidateExperience>> GetExperiencesAsync(int idCandidate);
        Task AddExperience(CandidateExperienceDTO experience);
    }
}
