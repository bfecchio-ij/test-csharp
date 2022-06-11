using Candidatos.Domain.Entities._CandidateExperience;
using Candidatos.Domain.Interfaces.Repositories;
using Candidatos.Domain.Interfaces.Services;

namespace Candidatos.Domain.Services
{
    public class CandidateExperienceService : ServiceBase<CandidateExperience>, ICandidateExperienceService
    {
        private readonly ICandidateExperienceRepository _repository;

        public CandidateExperienceService(ICandidateExperienceRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
