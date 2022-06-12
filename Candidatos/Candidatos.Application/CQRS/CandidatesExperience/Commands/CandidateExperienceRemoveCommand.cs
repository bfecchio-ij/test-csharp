using Candidatos.Domain.Entities;
using MediatR;

namespace Candidatos.Application.CQRS.CandidatesExperience.Commands
{
    public class CandidateExperienceRemoveCommand: IRequest<CandidateExperience>
    {
        public int IdCandidateExperience { get; set; }

        public CandidateExperienceRemoveCommand(int id)
        {
            IdCandidateExperience = id;
        }
    }
}
