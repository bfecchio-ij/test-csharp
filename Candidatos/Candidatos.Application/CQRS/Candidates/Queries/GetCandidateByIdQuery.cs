using Candidatos.Application.DTO;
using MediatR;

namespace Candidatos.Application.CQRS.Candidates.Queries
{
    public class GetCandidateByIdQuery: IRequest<CandidateDTO>
    {
        public int IdCandidate { get; set; }
        
        public GetCandidateByIdQuery(int id)
        {
            IdCandidate = id;
        }
    }
}
