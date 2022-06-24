using Flunt.Notifications;
using InfoJobs.Domain.Commands.Experiences;
using InfoJobs.Domain.Interfaces;
using InfoJobs.Shared.Commands;
using InfoJobs.Shared.Handlers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoJobs.Domain.Handlers.Experiences
{
    public class DeleteExperienceHandle : Notifiable<Notification>, IHandlerCommand<DeleteExperienceCommand>
    {
        private readonly IExperienceRepository _experienceRepository;

        public DeleteExperienceHandle(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public ICommandResult Handler(DeleteExperienceCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Correctly inform the experience you want to delete", command.Notifications);
            }

            var searchedExperience = _experienceRepository.SearchById(command.Id);

            if (searchedExperience == null)
            {
                return new GenericCommandResult(false, "Experience not found", command.Notifications);
            }

            _experienceRepository.Delete(searchedExperience.Id);

            return new GenericCommandResult(false, "Experience deleted successfully!", "");
        }
    }
}
