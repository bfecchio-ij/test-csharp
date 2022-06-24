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
    public class ListCandidateHandle : Notifiable<Notification>, IHandlerQuery<ListCandidateQuery>
    {
        private readonly ICandidateRepository _candidateRepository;

        public ListCandidateHandle(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public IQueryResult Handler(ListCandidateQuery query)
        {
            var list = _candidateRepository.List();

            return new GenericQueryResult(true, "Candidates found!", list);
        }
    }
}
