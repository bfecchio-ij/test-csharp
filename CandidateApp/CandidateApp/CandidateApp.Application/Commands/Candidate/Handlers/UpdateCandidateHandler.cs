using CandidateApp.Application.Commands.Candidate.Requests;
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
    public class UpdateCandidateHandler : IRequestHandler<UpdateCandidateRequest, bool>
    {
        private readonly ICandidateRepository _candidateRepository;

        public UpdateCandidateHandler(ICandidateRepository candidateRepository)
        {
            this._candidateRepository = candidateRepository;
        }
        public Task<bool> Handle(UpdateCandidateRequest request, CancellationToken cancellationToken)
        {

            var candidate = _candidateRepository.Get(request.Id);

            var candidateUpdated = new Domain.Entities.Candidate(request.Id,
                                            request.Name,
                                            request.Surname,
                                            request.Birthdate,
                                            candidate.InsertDate,
                                            request.Email);


            _candidateRepository.Update(candidateUpdated);

            var result = true;

            return Task.FromResult(result);
        }

    }
}
