using Candidatos.Application.DTO;
using MediatR;
using System.Collections.Generic;

namespace Candidatos.Application.CQRS.CandidatesExperience.Queries
{
    public class GetCandidatesExperienceQuery: IRequest<IEnumerable<CandidateExperienceDTO>>
    {

    }
}
