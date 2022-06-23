using CQRS.INFO.Models.Data;
using CQRS.INFO.Models.Entities;
using CQRS.INFO.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.INFO.Queries.ExperienceQueries
{
    public class GetExperienceByIdQuery : IRequest<CandidateExperience>
    {
        public int Id { get; set; }
        public class GetExperienceByIdQueryHandler : IRequestHandler<GetExperienceByIdQuery, CandidateExperience>
        {
            private readonly ICandidatesExperienceServices _experienceService;
            private readonly ApplicationContext _context;

            public GetExperienceByIdQueryHandler(ICandidatesExperienceServices experienceService, ApplicationContext context)
            {
                _experienceService = experienceService;
                _context = context;
            }

            public async Task<CandidateExperience> Handle(GetExperienceByIdQuery query, CancellationToken cancellationToken)
            {
                return await _experienceService.GetExperienceById(query.Id);
              //  return await _context.CandidatesExperiences
              //.Include(p => p.Candidate)
              //.FirstOrDefaultAsync(m => m.Id == query.Id);
            }
        }
    }
}
