using CQRS.INFO.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.INFO.Services.Interfaces
{
    public interface ICandidatesExperienceServices
    {
        Task<IEnumerable<CandidateExperience>> GetListOfExperiences();
        Task<CandidateExperience> GetExperienceById(int id);
        Task<CandidateExperience> CreateExperience(CandidateExperience experience);
        Task<int> UpdateExperience(CandidateExperience experience);
        Task<int> DeleteExperience(CandidateExperience experience);
    }
}
