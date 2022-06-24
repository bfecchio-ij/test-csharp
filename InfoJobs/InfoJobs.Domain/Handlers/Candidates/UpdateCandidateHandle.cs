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
    public class UpdateCandidateHandle : Notifiable<Notification>, IHandlerCommand<UpdateCandidateCommand>
    {
        private readonly ICandidateRepository _candidateRepository;

        public UpdateCandidateHandle(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public ICommandResult Handler(UpdateCandidateCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Enter the data correctly", command.Notifications);
            }

            Candidate oldCandidate = _candidateRepository.SearchById(command.Id);

            if (oldCandidate == null)
            {
                return new GenericCommandResult(false, "There is no candidates with this id", command.Notifications);
            }

            oldCandidate.UpdateCandidate(command.Name, command.Surname, command.BirthDate, command.Email);

            _candidateRepository.Update(oldCandidate);

            return new GenericCommandResult(true, "Candidate updated successfully!", oldCandidate);
        }
    }
}
