using Flunt.Notifications;
using InfoJobs.Domain.Interfaces;
using InfoJobs.Domain.Queries.Candidates;
using InfoJobs.Shared.Handlers.Contracts;
using InfoJobs.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoJobs.Domain.Handlers.Candidates
{
    public class SearchCandidateByIdHandle : Notifiable<Notification>, IHandlerQuery<SearchCandidateByIdQuery>
    {
        private readonly ICandidateRepository _candidateRepository;

        public SearchCandidateByIdHandle(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public IQueryResult Handler(SearchCandidateByIdQuery query)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new GenericQueryResult(false, "Correctly enter candidate data", query.Notifications);
            }

            var searchedCandidate = _candidateRepository.SearchById(query.Id);

            if (searchedCandidate == null)
            {
                return new GenericQueryResult(false, "Candidate not found", query.Notifications);
            }

            return new GenericQueryResult(true, "Candidate found!", searchedCandidate);
        }
    }
}
