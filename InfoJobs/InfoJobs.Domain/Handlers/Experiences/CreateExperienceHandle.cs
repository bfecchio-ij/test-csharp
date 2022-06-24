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
    public class CreateExperienceHandle : Notifiable<Notification>, IHandlerCommand<CreateExperienceCommand>
    {
        private readonly IExperienceRepository _experienceRepository;

        public CreateExperienceHandle(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public ICommandResult Handler(CreateExperienceCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Correctly enter experience data", command.Notifications);
            }

            CandidateExperience newExperience = new CandidateExperience(command.Company, command.Job, command.Description, command.Salary, command.BeginDate, command.EndDate, command.IdCandidates);

            if (!newExperience.IsValid)
            {
                return new GenericCommandResult(false, "Invalid experience data", newExperience.Notifications);
            }

            _experienceRepository.Add(newExperience);

            return new GenericCommandResult(true, "Experience created successfully!", newExperience);
        }
    }
}
