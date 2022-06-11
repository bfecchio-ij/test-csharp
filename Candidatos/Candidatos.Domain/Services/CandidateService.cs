using Candidatos.Domain.Entities._Candidate;
using Candidatos.Domain.Interfaces.Repositories;
using Candidatos.Domain.Interfaces.Services;

namespace Candidatos.Domain.Services
{
    public class CandidateService : ServiceBase<Candidate>, ICandidateService
    {
        private readonly ICandidateRepository _repository;
        
        public CandidateService(ICandidateRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
