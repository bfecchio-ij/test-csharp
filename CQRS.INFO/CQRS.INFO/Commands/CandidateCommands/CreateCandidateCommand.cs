using CQRS.INFO.Models.Entities;
using CQRS.INFO.Services.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.INFO.Commands.CandidateCommands
{
    public class CreateCandidateCommand : IRequest<Candidate>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, Candidate>
    {
        private readonly ICandidateServices _candidateService;

        public CreateCandidateCommandHandler(ICandidateServices candidateService)
        {
            _candidateService = candidateService;
        }

        public async Task<Candidate> Handle(CreateCandidateCommand command, CancellationToken cancellationToken)
        {
            var candidate = new Candidate()
            {
                Name = command.Name,
                Surname = command.Surname,
                BirthDate = command.BirthDate,
                Email = command.Email
            };

            if (await _candidateService.GetEmailChecked(candidate.Email) != null)
            {
                throw new Exception(
                "This email already exists.");
            }

            return await _candidateService.CreateCandidate(candidate);
        }
    }
}
