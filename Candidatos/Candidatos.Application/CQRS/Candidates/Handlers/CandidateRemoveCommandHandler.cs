using Candidatos.Application.CQRS.Candidates.Commands;
using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Candidatos.Application.CQRS.Candidates.Handlers
{
    public class CandidateRemoveCommandHandler : IRequestHandler<CandidateRemoveCommand, Candidate>
    {
        private readonly ICandidateRepository _repository;

        public CandidateRemoveCommandHandler(ICandidateRepository service)
        {
            _repository = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<Candidate> Handle(CandidateRemoveCommand request, CancellationToken cancellationToken)
        {
            var candidate = _repository.GetByIdAsync(request.IdCandidate).Result;
            if (candidate == null) throw new Exception("the candidate is null");
            return await _repository.RemoveAsync(candidate);
        }
    }
}
