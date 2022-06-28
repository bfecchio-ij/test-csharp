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


namespace CandidateApp.Application.Commands.Handlers
{
    public class CreateCandidateHandler :  IRequestHandler<CreateCandidateRequest, bool>
    {
        private readonly ICandidateRepository _candidateRepository;

        public CreateCandidateHandler(ICandidateRepository candidateRepository)
        {
            this._candidateRepository = candidateRepository;
        }
        public Task<bool> Handle(CreateCandidateRequest request, CancellationToken cancellationToken)
        {
            var candidate =
                new Domain.Entities.Candidate(request.Name,
                                            request.Surname,
                                            request.Birthdate,
                                            request.Email);


            _candidateRepository.Create(candidate);

            return Task.FromResult(true);
        }

    }
}
