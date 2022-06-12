using Candidatos.Application.CQRS.CandidatesExperience.Commands;
using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Candidatos.Application.CQRS.CandidatesExperience.Handlers
{
    public class CandidateExperienceCreateCommandHandler : IRequestHandler<CandidateExperienceCreateCommand, CandidateExperience>
    {
        private readonly ICandidateExperienceRepository _repository;

        public CandidateExperienceCreateCommandHandler(ICandidateExperienceRepository service)
        {
            _repository = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<CandidateExperience> Handle(CandidateExperienceCreateCommand request, CancellationToken cancellationToken)
        {
            var candidateExp = new CandidateExperience
            {
                BeginDate = request.BeginDate,
                EndDate = request.EndDate,
                Company = request.Company,
                Description = request.Description,
                Job = request.Job,
                Salary = request.Salary,
                IdCandidate = request.IdCandidate
            };

            if (candidateExp == null) throw new Exception("the candidate experience is null");
            return await _repository.CreateAsync(candidateExp);
        }
    }
}
