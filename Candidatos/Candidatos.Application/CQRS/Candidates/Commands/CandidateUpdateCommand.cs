namespace Candidatos.Application.CQRS.Candidates.Commands
{
    public class CandidateUpdateCommand: CandidateCommand
    {
        public int IdCandidate { get; set; }
    }
}
