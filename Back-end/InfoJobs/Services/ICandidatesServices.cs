using InfoJobs.Dtos;
using InfoJobs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoJobs.Services
{
    public interface ICandidatesServices
    {
       Task<IEnumerable<CandidatesDto>> GetAllCandidatesAsync();

        Task<CandidatesDto> GetCandidateAsyncById(int idCandidate);

        Task<CandidatesDto> PostCandidateAsync(CandidatesRequestDto candidateDto);
        Task<CandidatesDto> UpdateCandidateAsyncById(int id, CandidatesRequestDto candidateDto);

        Task<string> DeleteCandidateAsyncById(int id);

    }
}
