using CQRS.INFO.Models.Entities;
using CQRS.INFO.Services.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.INFO.Commands.ExperienceCommands
{
    public class DeleteExperienceCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteExperienceCommandHandler : IRequestHandler<DeleteExperienceCommand, int>
        {
            private readonly ICandidatesExperienceServices _experienceService;

            public DeleteExperienceCommandHandler(ICandidatesExperienceServices experienceService)
            {
                _experienceService = experienceService;
            }

            public async Task<int> Handle(DeleteExperienceCommand command, CancellationToken cancellationToken)
            {
                var experience = await _experienceService.GetExperienceById(command.Id);
                if (experience == null)
                    return default;

                return await _experienceService.DeleteExperience(experience);
            }
        }
    }
}
