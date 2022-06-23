using CQRS.INFO.Models.Entities;
using CQRS.INFO.Services.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.INFO.Commands.CandidateCommands
{
    public class DeleteCandidateCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand, int>
        {
            private readonly ICandidateServices _candidateService;

            public DeleteCandidateCommandHandler(ICandidateServices candidateService)
            {
                _candidateService = candidateService;
            }

            public async Task<int> Handle(DeleteCandidateCommand command, CancellationToken cancellationToken)
            {
                var candidate = await _candidateService.GetCandidateById(command.Id);
                if (candidate == null)
                    return default;

                return await _candidateService.DeleteCandidate(candidate);
            }
        }
    }
}
