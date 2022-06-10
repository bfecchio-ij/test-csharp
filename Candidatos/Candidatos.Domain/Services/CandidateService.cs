using Candidatos.Domain.Entities._Candidate;
using Candidatos.Domain.Interfaces.Repositories;

namespace Candidatos.Domain.Services
{
    public class CandidateService : ServiceBase<Candidate>
    {
        public CandidateService(IRepositoryBase<Candidate> repository) : base(repository)
        {
        }
    }
}
