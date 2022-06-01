using test_CSharp.Interfaces.Repositories;
using test_CSharp.Interfaces.Services;

namespace test_CSharp.Services
{
    public class CandidateExperienceService : ICandidateExperienceService
    {
        private readonly ICandidateExperienceRepository _repository;

        public CandidateExperienceService(ICandidateExperienceRepository repository)
        {
            _repository = repository;
        }
    }
}
