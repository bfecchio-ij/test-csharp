namespace Candidatos.Application.CQRS.CandidatesExperience.Commands
{
    public class CandidateExperienceUpdateCommand: CandidateExperienceCommand
    {
        public int IdCandidateExperience { get; set; }
    }
}
