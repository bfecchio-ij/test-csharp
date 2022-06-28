using CandidateApp.Application.Commands.Requests;
using CandidateApp.Application.Commands.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CandidateApp.Domain.Interfaces;
using CandidateApp.Domain.Entities;

namespace CandidateApp.Application.Commands.Handlers
{
    public class CreateCandidateExperienceHandler :  IRequestHandler<CreateCandidateExperienceRequest, bool>
    {
        private readonly ICandidateExperienceRepository _candidateExperienceRepository;
        private readonly ICandidateRepository _candidateRepository;

        public CreateCandidateExperienceHandler(ICandidateExperienceRepository candidateExperienceRepository, ICandidateRepository candidateRepository)
        {
            this._candidateExperienceRepository = candidateExperienceRepository;
            this._candidateRepository = candidateRepository;
        }

        public Task<bool> Handle(CreateCandidateExperienceRequest request, CancellationToken cancellationToken)
        {
            var candidate = _candidateRepository.Get(request.CandidateId);

            if (candidate == null)
                return Task.FromResult(false);

            var candidateExperience =
                new CandidateExperience(request.Company,
                                                                request.Job,
                                                                request.Description,
                                                                request.Salary,
                                                                request.BeginDate,
                                                                request.EndDate,
                                                                request.CandidateId);

            _candidateExperienceRepository.Create(candidateExperience);

            return Task.FromResult(true);
        }

    }
}
