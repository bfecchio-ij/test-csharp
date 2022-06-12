using Candidatos.Application.CQRS.Candidates.Commands;
using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Candidatos.Application.CQRS.Candidates.Handlers
{
    public class CandidateCreateCommandHandler : IRequestHandler<CandidateCreateCommand, Candidate>
    {
        private readonly ICandidateRepository _repository;

        public CandidateCreateCommandHandler(ICandidateRepository service)
        {
            _repository = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<Candidate> Handle(CandidateCreateCommand request, CancellationToken cancellationToken)
        {
            var candidate = new Candidate { Name = request.Name, Email = request.Email, BirthDate = request.BirthDate, Surname = request.Surname };
            if (candidate == null) throw new Exception("the candidate is null");
            return await _repository.CreateAsync(candidate);
        }
    }
}
