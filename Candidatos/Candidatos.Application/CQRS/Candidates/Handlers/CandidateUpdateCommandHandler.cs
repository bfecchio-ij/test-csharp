using Candidatos.Application.CQRS.Candidates.Commands;
using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Candidatos.Application.CQRS.Candidates.Handlers
{
    public class CandidateUpdateCommandHandler : IRequestHandler<CandidateUpdateCommand, Candidate>
    {
        private readonly ICandidateRepository _repository;

        public CandidateUpdateCommandHandler(ICandidateRepository service)
        {
            _repository = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<Candidate> Handle(CandidateUpdateCommand request, CancellationToken cancellationToken)
        {
            var candidate = _repository.GetByIdAsync(request.IdCandidate).Result;
            
            if (candidate == null) throw new Exception("the candidate is null");
            
            candidate.Name = request.Name;
            candidate.Surname = request.Surname;
            candidate.BirthDate = request.BirthDate;
            candidate.Email = request.Email;

            return await _repository.UpdateAsync(candidate);
        }
    }
}
