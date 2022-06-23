using CQRS.INFO.Models.Entities;
using CQRS.INFO.Services.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.INFO.Commands.ExperienceCommands
{
    public class UpdateExperienceCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public class UpdateExperienceCommandHandler : IRequestHandler<UpdateExperienceCommand, int>
        {
            private readonly ICandidatesExperienceServices _experienceService;

            public UpdateExperienceCommandHandler(ICandidatesExperienceServices experienceService)
            {
                _experienceService = experienceService;
            }

            public async Task<int> Handle(UpdateExperienceCommand command, CancellationToken cancellationToken)
            {
                var experience = await _experienceService.GetExperienceById(command.Id);
                if (experience == null)
                    return default;
                experience.CandidateId = command.CandidateId;
                experience.Company = command.Company;
                experience.Job = command.Job;
                experience.Description = command.Description;
                experience.Salary = command.Salary;
                experience.BeginDate = command.BeginDate;
                experience.EndDate = command.EndDate;

                return await _experienceService.UpdateExperience(experience);
            }
        }
    }
}
