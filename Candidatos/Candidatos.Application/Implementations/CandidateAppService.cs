using Candidatos.Application.Interfaces;
using Candidatos.Domain.Entities._Candidate;
using Candidatos.Domain.Interfaces.Services;

namespace Candidatos.Application.Implementations
{
    public class CandidateAppService : AppServiceBase<Candidate>, ICandidateAppService
    {
        public CandidateAppService(ICandidateService service) : base(service)
        {
        }
    }
}
