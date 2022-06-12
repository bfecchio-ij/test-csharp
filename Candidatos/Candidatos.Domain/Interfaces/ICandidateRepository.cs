using Candidatos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidatos.Domain.Interfaces
{
    public interface ICandidateRepository
    {
        // queries
        Task<IEnumerable<Candidate>> GetCandidatesAsync();
        Task<Candidate> GetByIdAsync(int? id);

        // commands
        Task<Candidate> CreateAsync(Candidate candidate);
        Task<Candidate> UpdateAsync(Candidate candidate);
        Task<Candidate> RemoveAsync(Candidate candidate);
    }
}
