using Candidatos.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidatos.Application.CQRS.Candidates.Queries
{
    public class GetCandidateByIdWithExperiences: IRequest<CandidateDetails>
    {
        public int IdCandidate { get; set; }

        public GetCandidateByIdWithExperiences(int id)
        {
            IdCandidate = id;
        }
    }
}
