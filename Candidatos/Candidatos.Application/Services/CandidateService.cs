using AutoMapper;
using Candidatos.Application.CQRS.Candidates.Commands;
using Candidatos.Application.CQRS.Candidates.Queries;
using Candidatos.Application.DTO;
using Candidatos.Application.Interfaces;
using Candidatos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidatos.Application.Implementations
{
    public class CandidateService : ICandidateService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CandidateService(ICandidateRepository repository, IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<CandidateDTO>> GetAllAsync()
        {
            var q = new GetCandidatesQuery();
            if (q == null) throw new ApplicationException("Error getting candidates");
            
            var candidates = await _mediator.Send(q);
            return _mapper.Map<IEnumerable<CandidateDTO>>(candidates);
        }

        public async Task<CandidateDTO> GetByIdAsync(int? id)
        {
            var q = new GetCandidateByIdQuery(id.Value);
            if (q == null) throw new ApplicationException("Error getting candidate");

            var candidate = await _mediator.Send(q);
            return _mapper.Map<CandidateDTO>(candidate);
        }

        public async Task<bool> GetByEmail(string email)
        {
            var q = new GetCandidateByEmailQuery(email);
            if (q == null) throw new ApplicationException("Error getting candidate");

            var candidate = await _mediator.Send(q);
            return candidate;
        }

        public async Task<CandidateDetails> GetByIdWithExperiencesAsync(int? id)
        {
            var q = new GetCandidateByIdWithExperiences(id.Value);
            if (q == null) throw new ApplicationException("Error getting candidate");

            var candidate = await _mediator.Send(q);
            return _mapper.Map<CandidateDetails>(candidate);
        }
        
        public async Task CreateAsync(CandidateDTO candidateDTO)
        {
            var q = _mapper.Map<CandidateCreateCommand>(candidateDTO);
            if (q == null) throw new ApplicationException("Error creating candidate");
            
            await _mediator.Send(q);
        }

        public async Task UpdateAsync(CandidateDTO candidateDTO)
        {
            var q = _mapper.Map<CandidateUpdateCommand>(candidateDTO);
            if (q == null) throw new ApplicationException("Error updating candidate");

            await _mediator.Send(q);
        }
        
        public async Task RemoveAsync(CandidateDTO candidateDTO)
        {
            var q = new CandidateRemoveCommand(candidateDTO.IdCandidate);
            if (q == null) throw new ApplicationException("Error removing candidate");

            await _mediator.Send(q);
        }

        public async Task RemoveAsync(int? id)
        {
            var q = new CandidateRemoveCommand(id.Value);
            if (q == null) throw new ApplicationException("Error removing candidate");

            await _mediator.Send(q);
        }
    }
}
