using Flunt.Notifications;
using InfoJobs.Domain.Commands.Experiences;
using InfoJobs.Domain.Entities;
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
    public class UpdateExperienceHandle : Notifiable<Notification>, IHandlerCommand<UpdateExperienceCommand>
    {
        private readonly IExperienceRepository _experienceRepository;

        public UpdateExperienceHandle(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public ICommandResult Handler(UpdateExperienceCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Enter the data correctly", command.Notifications);
            }

            CandidateExperience oldExperience = _experienceRepository.SearchById(command.Id);

            if (oldExperience == null)
            {
                return new GenericCommandResult(false, "There is no experiences with this id", command.Notifications);
            }

            oldExperience.UpdateExperience(command.Id, command.Company, command.Job, command.Description, command.Salary, command.BeginDate, command.EndDate);

            _experienceRepository.Update(oldExperience);

            return new GenericCommandResult(true, "Experience updated successfully!", oldExperience);
        }
    }
}
