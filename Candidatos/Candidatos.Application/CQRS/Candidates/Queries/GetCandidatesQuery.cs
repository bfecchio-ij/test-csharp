using Candidatos.Application.DTO;
using MediatR;
using System.Collections.Generic;

namespace Candidatos.Application.CQRS.Candidates.Queries
{
    public class GetCandidatesQuery: IRequest<IEnumerable<CandidateDTO>>
    {
       
    }
}
