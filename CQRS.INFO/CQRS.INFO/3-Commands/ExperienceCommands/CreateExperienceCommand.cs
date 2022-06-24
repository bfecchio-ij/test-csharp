using CQRS.INFO.Models.Entities;
using CQRS.INFO.Services.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.INFO.Commands.ExperienceCommands
{
    public class CreateExperienceCommand : IRequest<CandidateExperience>
    {
        public int CandidateId { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class CreateExperienceCommandHandler : IRequestHandler<CreateExperienceCommand, CandidateExperience>
    {
        private readonly ICandidatesExperienceServices _experienceService;

        public CreateExperienceCommandHandler(ICandidatesExperienceServices experienceService)
        {
            _experienceService = experienceService;
        }

        public async Task<CandidateExperience> Handle(CreateExperienceCommand command, CancellationToken cancellationToken)
        {
            var experience = new CandidateExperience()
            {
                CandidateId = command.CandidateId,
                Company = command.Company,
                Job = command.Job,
                Description = command.Description,
                Salary = command.Salary,
                BeginDate = command.BeginDate,
                EndDate = command.EndDate,
            };

            return await _experienceService.CreateExperience(experience);
        }
    }
}
