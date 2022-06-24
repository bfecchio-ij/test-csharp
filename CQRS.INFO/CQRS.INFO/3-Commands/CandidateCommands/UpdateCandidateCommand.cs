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

                var usedCandidatesEmail = await _candidateService.CheckIfEmailIsUnique(candidate.Email);

                if (usedCandidatesEmail != null && usedCandidatesEmail.Id != candidate.Id)
                {
                    if (!usedCandidatesEmail.Equals(candidate))
                    {
                        AddError("The candidate's e-mail has already being used.");
                        //throw new Exception("This email is  already being used.");
                    }
                }

                return await _candidateService.UpdateCandidate(candidate);
            }

            private void AddError(string errorMessage)
            {
                throw new NotImplementedException();
            }
        }
    }
}
