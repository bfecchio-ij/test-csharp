using CandidateApp.Application.Commands.Candidate.Requests;
using CandidateApp.Domain.Entities;
using CandidateApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CandidateApp.Application.Commands.Candidate.Handlers
{
    public class UpdateCandidateExperienceHandler : IRequestHandler<UpdateCandidateExperienceRequest, bool>
    {
        private readonly ICandidateExperienceRepository _candidateExperienceRepository;

        public UpdateCandidateExperienceHandler(ICandidateExperienceRepository candidateExperienceRepository)
        {
            this._candidateExperienceRepository = candidateExperienceRepository;
        }

        public Task<bool> Handle(UpdateCandidateExperienceRequest request, CancellationToken cancellationToken)
        {
            var candidateExperience = _candidateExperienceRepository.Get(request.Id);

            if (candidateExperience == null)
                return Task.FromResult(false); 

            var candidateExperienceUpdated =
                new CandidateExperience(request.Id,
                                                                request.Company,
                                                                request.Job,
                                                                request.Description,
                                                                request.Salary,
                                                                request.BeginDate,
                                                                request.EndDate,
                                                                candidateExperience.InsertDate,
                                                                candidateExperience.CandidateId);

            _candidateExperienceRepository.Update(candidateExperienceUpdated);

            return Task.FromResult(true);
        }

    }
}
