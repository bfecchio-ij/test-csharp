using Candidatos.Domain.Entities;
using MediatR;
using System;

namespace Candidatos.Application.CQRS.CandidatesExperience.Commands
{
    public class CandidateExperienceCommand: IRequest<CandidateExperience>
    {
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int IdCandidate { get; set; }
    }
}
