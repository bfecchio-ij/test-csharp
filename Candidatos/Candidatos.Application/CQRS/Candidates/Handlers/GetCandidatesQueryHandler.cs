using Candidatos.Application.CQRS.Candidates.Queries;
using Candidatos.Application.DTO;
using Candidatos.Application.Interfaces;
using Candidatos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Candidatos.Application.CQRS.Candidates.Handlers
{
    public class GetCandidatesQueryHandler : IRequestHandler<GetCandidatesQuery, IEnumerable<CandidateDTO>>
    {
        private readonly ICandidateRepository _repository;

        public GetCandidatesQueryHandler(ICandidateService service, ICandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CandidateDTO>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
        {
            var listResult = new List<CandidateDTO>();
            var candidates = await _repository.GetCandidatesAsync();
            if (candidates == null) throw new Exception("the candidates are null");

            foreach (var candidate in candidates)
            {
                listResult.Add(new CandidateDTO
                {
                    Name = candidate.Name,
                    Surname = candidate.Surname,
                    Email = candidate.Email,
                    BirthDate = candidate.BirthDate,
                    IdCandidate = candidate.IdCandidate
                });
            }

            return listResult;
        }
    }
}
