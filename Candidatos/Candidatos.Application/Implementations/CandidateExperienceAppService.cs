using Candidatos.Application.Interfaces;
using Candidatos.Domain.Entities._CandidateExperience;
using Candidatos.Domain.Interfaces.Services;

namespace Candidatos.Application.Implementations
{
    public class CandidateExperienceAppService : AppServiceBase<CandidateExperience>, ICandidateExperienceAppService
    {
        public CandidateExperienceAppService(ICandidateExperienceService service) : base(service)
        {
        }
    }
}
