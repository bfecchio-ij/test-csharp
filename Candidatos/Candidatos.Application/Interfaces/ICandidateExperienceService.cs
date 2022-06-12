using Candidatos.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidatos.Application.Interfaces
{
    public interface ICandidateExperienceService
    {
        // queries
        Task<IEnumerable<CandidateExperienceDTO>> GetAllAsync();
        Task<CandidateExperienceDTO> GetByIdAsync(int? id);

        // commands
        Task CreateAsync(CandidateExperienceCommandDTO candidateExperienceDTO);
        Task UpdateAsync(CandidateExperienceCommandDTO candidateExperienceDTO);
        Task RemoveAsync(int? id);
    }
}
