using AutoMapper;
using CandidateApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CandidateApp.Application.Querys.Candidate
{
    public class GetAllCandidatesHandler : IRequestHandler<GetAllCandidatesRequest, IEnumerable<GetAllCandidatesViewModel>>
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly IMapper mapper;

        public GetAllCandidatesHandler(ICandidateRepository candidateRepository, IMapper mapper)
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
        }

        public Task<IEnumerable<GetAllCandidatesViewModel>> Handle(GetAllCandidatesRequest request, CancellationToken cancellationToken)
        {
            var candidate = candidateRepository.GetAll();
            var candidateViewModel = mapper.Map<IEnumerable<GetAllCandidatesViewModel>>(candidate);

            return Task.FromResult(candidateViewModel);
        }
    }
}
