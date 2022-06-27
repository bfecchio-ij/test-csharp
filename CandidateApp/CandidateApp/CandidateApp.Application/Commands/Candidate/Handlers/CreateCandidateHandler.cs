using CandidateApp.Application.Commands.Requests;
using CandidateApp.Application.Commands.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CandidateApp.Application.Commands.Handlers
{
    public class CreateCandidateHandler : IRequestHandler<CreateCandidateRequest, bool>
    {
        public Task<bool> Handle(CreateCandidateRequest request, CancellationToken cancellationToken)
        {
            var result = true;

            return Task.FromResult(result);
        }

    }
}
