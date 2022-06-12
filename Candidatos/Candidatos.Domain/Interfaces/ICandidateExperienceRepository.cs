using Candidatos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidatos.Domain.Interfaces
{
    public interface ICandidateExperienceRepository
    {
        // queries
        Task<IEnumerable<CandidateExperience>> GetCandidateExperiencesAsync();
        Task<CandidateExperience> GetByIdAsync(int? id);

        // commands
        Task<CandidateExperience> CreateAsync(CandidateExperience candidateExperience);
        Task<CandidateExperience> UpdateAsync(CandidateExperience candidateExperience);
        Task<CandidateExperience> RemoveAsync(CandidateExperience candidateExperience);
    }
}
