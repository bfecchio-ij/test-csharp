using Flunt.Notifications;
using InfoJobs.Domain.Commands.Candidates;
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
    public class DeleteCandidateHandle : Notifiable<Notification>, IHandlerCommand<DeleteCandidateCommand>
    {
        private readonly ICandidateRepository _candidateRepository;

        public DeleteCandidateHandle(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public ICommandResult Handler(DeleteCandidateCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Correctly inform the candidate you want to delete", command.Notifications);
            }

            var searchedCandidate = _candidateRepository.SearchById(command.Id);

            if (searchedCandidate == null)
            {
                return new GenericCommandResult(false, "Candidate not found", command.Notifications);
            }

            _candidateRepository.Delete(searchedCandidate);

            return new GenericCommandResult(false, "Candidate deleted successfully!", "");
        }
    }
}
