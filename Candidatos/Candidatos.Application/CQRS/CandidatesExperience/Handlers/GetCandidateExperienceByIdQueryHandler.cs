using Candidatos.Application.CQRS.CandidatesExperience.Queries;
using Candidatos.Application.DTO;
using Candidatos.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Candidatos.Application.CQRS.CandidatesExperience.Handlers
{
    public class GetCandidateExperienceByIdQueryHandler : IRequestHandler<GetCandidateExperienceByIdQuery, CandidateExperienceDTO>
    {
        private readonly ICandidateExperienceRepository _repository;

        public GetCandidateExperienceByIdQueryHandler(ICandidateExperienceRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<CandidateExperienceDTO> Handle(GetCandidateExperienceByIdQuery request, CancellationToken cancellationToken)
        {
            var candidateExp = await _repository.GetByIdAsync(request.IdCandidateExperience);
            if (candidateExp == null) return null;

            return new CandidateExperienceDTO
            {
                BeginDate = candidateExp.BeginDate,
                EndDate = candidateExp.EndDate,
                IdCandidateExperience = candidateExp.IdCandidateExperience,
                IdCandidate = candidateExp.IdCandidate,
                Company = candidateExp.Company,
                Description = candidateExp.Description,
                Job = candidateExp.Job,
                Salary = candidateExp.Salary,
                CandidateBirthDate = candidateExp.Candidate.BirthDate,
                CandidateEmail = candidateExp.Candidate.Email,
                CandidateName = candidateExp.Candidate.Name,
                CandidateSurname = candidateExp.Candidate.Surname
            };
        }
    }
}
