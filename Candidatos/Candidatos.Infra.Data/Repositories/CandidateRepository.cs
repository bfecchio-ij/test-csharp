using Candidatos.Domain.Entities._Candidate;
using Candidatos.Domain.Interfaces.Repositories;

namespace Candidatos.Infra.Data.Repositories
{
    public class CandidateRepository : RepositoryBase<Candidate>, ICandidateRepository
    {
    }
}
