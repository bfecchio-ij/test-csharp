using Candidatos.Domain.Entities;
using MediatR;

namespace Candidatos.Application.CQRS.Candidates.Commands
{
    public class CandidateRemoveCommand: IRequest<Candidate>
    {
        public int IdCandidate { get; set; }
        
        public CandidateRemoveCommand(int id)
        {
            IdCandidate = id;
        }
    }
}
