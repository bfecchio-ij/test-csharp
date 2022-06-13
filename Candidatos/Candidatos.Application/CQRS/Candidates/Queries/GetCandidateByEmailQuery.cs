using Candidatos.Application.DTO;
using MediatR;

namespace Candidatos.Application.CQRS.Candidates.Queries
{
    public class GetCandidateByEmailQuery : IRequest<bool>
    {
        public string Email { get; set; }
        
        public GetCandidateByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
