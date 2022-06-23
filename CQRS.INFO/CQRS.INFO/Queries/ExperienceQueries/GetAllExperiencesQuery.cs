using CQRS.INFO.Models.Data;
using CQRS.INFO.Models.Entities;
using CQRS.INFO.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.INFO.Queries.ExperienceQueries
{
    public class GetAllExperiencesQuery : IRequest<IEnumerable<CandidateExperience>>
    {
        public class GetAllExperiencesQueryHandler : IRequestHandler<GetAllExperiencesQuery, IEnumerable<CandidateExperience>>
        {
            private readonly ICandidatesExperienceServices _experienceService;
            private readonly ApplicationContext _context;

            public GetAllExperiencesQueryHandler(ICandidatesExperienceServices experienceService, ApplicationContext context)
            {
                _experienceService = experienceService;
                _context = context;
            }

            public async Task<IEnumerable<CandidateExperience>> Handle(GetAllExperiencesQuery query, CancellationToken cancellationToken)
            {
               // return await _experienceService.GetListOfExperiences();
               return await _context.CandidatesExperiences.Include(p => p.Candidate).ToListAsync();
            }
        }
    }
}
