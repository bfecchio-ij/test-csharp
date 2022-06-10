using Candidatos.Domain.Entities._CandidateExperience;
using Candidatos.Domain.Interfaces.Repositories;

namespace Candidatos.Domain.Services
{
    public class CandidateExperienceService : ServiceBase<CandidateExperience>
    {
        public CandidateExperienceService(IRepositoryBase<CandidateExperience> repository) : base(repository)
        {
        }
    }
}
