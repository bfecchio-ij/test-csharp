using AutoMapper;
using Candidatos.Application.CQRS.CandidatesExperience.Commands;
using Candidatos.Application.CQRS.CandidatesExperience.Queries;
using Candidatos.Application.DTO;
using Candidatos.Application.Interfaces;
using Candidatos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidatos.Application.Implementations
{
    public class CandidateExperienceService : ICandidateExperienceService
    {
        private readonly ICandidateExperienceRepository _repository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CandidateExperienceService(ICandidateExperienceRepository repository, IMapper mapper, IMediator mediator)
        {
            _repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<CandidateExperienceDTO>> GetAllAsync()
        {
            var q = new GetCandidatesExperienceQuery();
            if (q == null) throw new ApplicationException("Error getting candidates experience");

            var candidatesExp = await _mediator.Send(q);
            return _mapper.Map<IEnumerable<CandidateExperienceDTO>>(candidatesExp);
        }

        public async Task<CandidateExperienceDTO> GetByIdAsync(int? id)
        {
            var q = new GetCandidateExperienceByIdQuery(id.Value);
            if (q == null) throw new ApplicationException("Error getting candidate experience");

            var candidatesExp = await _mediator.Send(q);
            return candidatesExp;
        }
        
        public async Task CreateAsync(CandidateExperienceCommandDTO candidateExperienceCommandDTO)
        {
            var q = _mapper.Map<CandidateExperienceCreateCommand>(candidateExperienceCommandDTO);
            if (q == null) throw new ApplicationException("Error creating candidate experience");

            await _mediator.Send(q);
        }

        public async Task UpdateAsync(CandidateExperienceCommandDTO candidateExperienceCommandDTO)
        {
            var q = _mapper.Map<CandidateExperienceUpdateCommand>(candidateExperienceCommandDTO);
            if (q == null) throw new ApplicationException("Error updating candidate experience");

            await _mediator.Send(q);
        }
        
        public async Task RemoveAsync(int? id)
        {
            var q = new CandidateExperienceRemoveCommand(id.Value);
            if (q == null) throw new ApplicationException("Error removing candidate experience");

            await _mediator.Send(q);
        }
    }
}
