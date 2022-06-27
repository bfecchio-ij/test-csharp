using CandidateApp.Application.Commands.Candidate.Requests;
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
        public Task<bool> Handle(UpdateCandidateRequest request, CancellationToken cancellationToken)
        {
            var result = true;

            return Task.FromResult(result);
        }

    }
}
