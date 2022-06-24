using Flunt.Notifications;
using InfoJobs.Domain.Commands.Candidates;
using InfoJobs.Domain.Entities;
using InfoJobs.Domain.Interfaces;
using InfoJobs.Shared.Commands;
using InfoJobs.Shared.Handlers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoJobs.Domain.Handlers.Candidates
{
    public class CreateCandidateHandle : Notifiable<Notification>, IHandlerCommand<CreateCandidateCommand>
    {
        private readonly ICandidateRepository _candidateRepository;

        public CreateCandidateHandle(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public ICommandResult Handler(CreateCandidateCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Correctly enter candidate data", command.Notifications);
            }

            var emailExists = _candidateRepository.SearchByEmail(command.Email);

            if (emailExists != null)
            {
                return new GenericCommandResult(false, "Existing e-mail", "Enter another e-mail");
            }

            Candidate newCandidate = new Candidate(command.Name, command.Surname, command.BirthDate, command.Email);

            if (!newCandidate.IsValid)
            {
                return new GenericCommandResult(false, "Invalid candidate data", newCandidate.Notifications);
            }

            _candidateRepository.Add(newCandidate);

            return new GenericCommandResult(true, "Candidate created successfully!", newCandidate);
        }
    }
}
