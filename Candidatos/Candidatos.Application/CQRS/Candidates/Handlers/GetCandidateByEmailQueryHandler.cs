using Candidatos.Application.CQRS.Candidates.Queries;
using Candidatos.Application.DTO;
using Candidatos.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Candidatos.Application.CQRS.Candidates.Handlers
{
    public class GetCandidateByEmailQueryHandler : IRequestHandler<GetCandidateByEmailQuery, bool>
    {
        private readonly ICandidateRepository _repository;

        public GetCandidateByEmailQueryHandler(ICandidateRepository service)
        {
            _repository = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<bool> Handle(GetCandidateByEmailQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _repository.GetByEmail(request.Email);
            return candidate;
        }
    }
}
