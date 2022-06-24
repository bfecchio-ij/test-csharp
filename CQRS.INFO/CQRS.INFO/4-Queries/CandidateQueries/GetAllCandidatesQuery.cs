using CQRS.INFO.Models.Entities;
using CQRS.INFO.Services.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.INFO.Queries.CandidateQueries
{
    public class GetAllCandidatesQuery : IRequest<IEnumerable<Candidate>>
    {
        public class GetAllCandidatesQueryHandler : IRequestHandler<GetAllCandidatesQuery, IEnumerable<Candidate>>
        {
            private readonly ICandidateServices _candidateService;

            public GetAllCandidatesQueryHandler(ICandidateServices candidateService)
            {
                _candidateService = candidateService;
            }

            public async Task<IEnumerable<Candidate>> Handle(GetAllCandidatesQuery query, CancellationToken cancellationToken)
            {
                return await _candidateService.GetListOfCandidates();
            }
        }

    }
}
