using InfoJobs.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoJobs.Services
{
    public interface ICandidateExperiencesServices
    {


        Task<IEnumerable<CandidateExperiencesDto>> GetAllExperiences();
        Task<CandidateExperiencesDto> GetExperienceAsyncById(int idExperience);

        Task<IEnumerable<CandidateExperiencesDto>> GetExperienceAsyncByCandidateId(int idCandidate);
        Task<CandidateExperiencesDto> PostExperienceAsync(CandidateExperiencesRequestDto experienceDto);

        Task<CandidateExperiencesDto> UpdateCandidateExperienceAsyncById(int id, CandidateExperiencesRequestDto experienceDto);

        Task<string> DeleteCandidateExperienceAsyncById(int id);

    }
}
