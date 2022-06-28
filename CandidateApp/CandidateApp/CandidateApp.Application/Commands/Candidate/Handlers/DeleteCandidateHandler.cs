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
    public class DeleteCandidateHandler : IRequestHandler<DeleteCandidateRequest, bool>
    {
        private readonly ICandidateRepository _candidateRepository;

        public DeleteCandidateHandler(ICandidateRepository candidateRepository)
        {
            this._candidateRepository = candidateRepository;
        }
        public Task<bool> Handle(DeleteCandidateRequest request, CancellationToken cancellationToken)
        {

            _candidateRepository.Delete(c => c.Id == request.Id);

            var result = true;

            return Task.FromResult(result);
        }

    }
}
