using Candidatos.Application.CQRS.CandidatesExperience.Commands;
using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Candidatos.Application.CQRS.CandidatesExperience.Handlers
{
    public class CandidateExperienceRemoveCommandHandler : IRequestHandler<CandidateExperienceRemoveCommand, CandidateExperience>
    {
        private readonly ICandidateExperienceRepository _repository;

        public CandidateExperienceRemoveCommandHandler(ICandidateExperienceRepository service)
        {
            _repository = service ?? throw new ArgumentNullException(nameof(service));
        }
        
        public async Task<CandidateExperience> Handle(CandidateExperienceRemoveCommand request, CancellationToken cancellationToken)
        {
            var candidateExp = _repository.GetByIdAsync(request.IdCandidateExperience).Result;
            if (candidateExp == null) return null;
            return await _repository.RemoveAsync(candidateExp);
        }
    }
}
