using Candidatos.Application.CQRS.CandidatesExperience.Commands;
using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Candidatos.Application.CQRS.CandidatesExperience.Handlers
{
    public class CandidateExperienceUpdateCommandHandler : IRequestHandler<CandidateExperienceUpdateCommand, CandidateExperience>
    {
        private readonly ICandidateExperienceRepository _repository;

        public CandidateExperienceUpdateCommandHandler(ICandidateExperienceRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<CandidateExperience> Handle(CandidateExperienceUpdateCommand request, CancellationToken cancellationToken)
        {
            var candidateExp = _repository.GetByIdAsync(request.IdCandidate).Result;
            
            if (candidateExp == null) throw new Exception("the candidate is null");
            
            candidateExp.BeginDate = request.BeginDate;
            candidateExp.EndDate = request.EndDate;
            candidateExp.Company = request.Company;
            candidateExp.Description = request.Description;
            candidateExp.Job = request.Job;
            candidateExp.Salary = request.Salary;
            candidateExp.IdCandidateExperience = request.IdCandidateExperience;
            candidateExp.IdCandidate = request.IdCandidate;

            return await _repository.UpdateAsync(candidateExp);
        }
    }
}
