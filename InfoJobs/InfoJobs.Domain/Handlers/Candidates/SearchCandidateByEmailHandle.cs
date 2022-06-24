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
    public class SearchCandidateByEmailHandle : Notifiable<Notification>, IHandlerQuery<SearchCandidateByEmailQuery>
    {
        private readonly ICandidateRepository _candidateRepository;

        public SearchCandidateByEmailHandle(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public IQueryResult Handler(SearchCandidateByEmailQuery query)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new GenericQueryResult(false, "Correctly enter candidate data", query.Notifications);
            }

            var searchedCandidate = _candidateRepository.SearchByEmail(query.Email);

            if (searchedCandidate == null)
            {
                return new GenericQueryResult(false, "Candidate not found", query.Notifications);
            }

            return new GenericQueryResult(true, "Candidate found!", searchedCandidate);
        }
    }
}