using Candidatos.Application.CQRS.Candidates.Queries;
using Candidatos.Application.DTO;
using Candidatos.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Candidatos.Application.CQRS.Candidates.Handlers
{
    public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, CandidateDTO>
    {
        private readonly ICandidateRepository _repository;

        public GetCandidateByIdQueryHandler(ICandidateRepository service)
        {
            _repository = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<CandidateDTO> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _repository.GetByIdAsync(request.IdCandidate);
            if (candidate == null) throw new Exception("the candidate is null");

            return new CandidateDTO
            {
                IdCandidate = candidate.IdCandidate,
                Name = candidate.Name,
                Surname = candidate.Surname,
                BirthDate = candidate.BirthDate,
                Email = candidate.Email
            };
        }
    }
}
