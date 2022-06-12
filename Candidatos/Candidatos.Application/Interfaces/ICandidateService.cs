using Candidatos.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidatos.Application.Interfaces
{
    public interface ICandidateService
    {
        // queries
        Task<IEnumerable<CandidateDTO>> GetAllAsync();
        Task<CandidateDTO> GetByIdAsync(int? id);
        
        // commands
        Task CreateAsync(CandidateDTO candidateDTO);
        Task UpdateAsync(CandidateDTO candidateDTO);
        Task RemoveAsync(int? id);
    }
}
