using Candidatos.Application.CQRS.Candidates.Queries;
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

namespace Candidatos.Application.CQRS.Candidates.Handlers
{
    public class GetCandidateByIdWithExperiencesHandler : IRequestHandler<GetCandidateByIdWithExperiences, CandidateDetails>
    {
        private readonly ICandidateRepository _repository;

        public GetCandidateByIdWithExperiencesHandler(ICandidateRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<CandidateDetails> Handle(GetCandidateByIdWithExperiences request, CancellationToken cancellationToken)
        {
            var candidate = await _repository.GetByIdWithExperiencesAsync(request.IdCandidate);
            if (candidate == null) return null;

            var ce = new CandidateDetails
            {
                Name = candidate.Name,
                Surname = candidate.Surname,
                BirthDate = candidate.BirthDate,
                Email = candidate.Email,
                IdCandidate = candidate.IdCandidate,
                Experiences = candidate.CandidateExperiences
            };

            List<CandidateExperience> exp = new List<CandidateExperience>();
            foreach (var item in candidate.CandidateExperiences)
            {
                exp.Add(new CandidateExperience {
                    BeginDate = item.BeginDate,
                    EndDate = item.EndDate,
                    Company = item.Company,
                    Description = item.Description,
                    Job = item.Job,
                    Salary = item.Salary,
                    IdCandidateExperience = item.IdCandidateExperience,
                });
            }

            ce.Experiences = exp;

            return ce;
        }
    }
}
