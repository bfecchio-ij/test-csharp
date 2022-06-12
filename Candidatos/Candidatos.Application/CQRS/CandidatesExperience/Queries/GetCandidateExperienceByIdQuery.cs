using Candidatos.Application.DTO;
using MediatR;

namespace Candidatos.Application.CQRS.CandidatesExperience.Queries
{
    public class GetCandidateExperienceByIdQuery: IRequest<CandidateExperienceDTO>
    {
        public int IdCandidateExperience { get; set; }

        public GetCandidateExperienceByIdQuery(int id)
        {
            IdCandidateExperience = id;
        }
    }
}
