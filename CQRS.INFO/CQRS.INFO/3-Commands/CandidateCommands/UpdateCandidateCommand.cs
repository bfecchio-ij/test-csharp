using CQRS.INFO.Models.Entities;
using CQRS.INFO.Services.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.INFO.Commands.CandidateCommands
{
    public class UpdateCandidateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }

        public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, int>
        {
            private readonly ICandidateServices _candidateService;

            public UpdateCandidateCommandHandler(ICandidateServices candidateService)
            {
                _candidateService = candidateService;
            }

            public async Task<int> Handle(UpdateCandidateCommand command, CancellationToken cancellationToken)
            {
                var candidate = await _candidateService.GetCandidateById(command.Id);
                if (candidate == null)
                    return default;

                candidate.Name = command.Name;
                candidate.Surname = command.Surname;
                candidate.BirthDate = command.BirthDate;
                candidate.Email = command.Email;

                return await _candidateService.UpdateCandidate(candidate);
            }
        }
    }
}
