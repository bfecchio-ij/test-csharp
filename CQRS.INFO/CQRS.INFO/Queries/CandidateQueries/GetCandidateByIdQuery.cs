using CQRS.INFO.Models.Entities;
using CQRS.INFO.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.INFO.Queries.CandidateQueries
{
    public class GetCandidateByIdQuery : IRequest<Candidate>
    {
        public int Id { get; set; }

        public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, Candidate>
        {
            private readonly ICandidateServices _candidateService;

            public GetCandidateByIdQueryHandler(ICandidateServices candidateService)
            {
                _candidateService = candidateService;
            }

            public async Task<Candidate> Handle(GetCandidateByIdQuery query, CancellationToken cancellationToken)
            {
                return await _candidateService.GetCandidateById(query.Id);
            }
        }

    }
}
