using Candidatos.Application.CQRS.CandidatesExperience.Queries;
using Candidatos.Application.DTO;
using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Candidatos.Application.CQRS.CandidatesExperience.Handlers
{
    public class GetCandidatesExperienceQueryHandler : IRequestHandler<GetCandidatesExperienceQuery, IEnumerable<CandidateExperienceDTO>>
    {
        private readonly ICandidateExperienceRepository _repository;

        public GetCandidatesExperienceQueryHandler(ICandidateExperienceRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<CandidateExperienceDTO>> Handle(GetCandidatesExperienceQuery request, CancellationToken cancellationToken)
        {
            var listResult = new List<CandidateExperienceDTO>();
            var candidatesExp = await _repository.GetCandidateExperiencesAsync();
            if (candidatesExp == null) return listResult;

            foreach (var candidateExp in candidatesExp)
            {
                listResult.Add(new CandidateExperienceDTO
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
                });
            }

            return listResult;
        }
    }
}
