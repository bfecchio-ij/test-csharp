using Flunt.Notifications;
using InfoJobs.Domain.Interfaces;
using InfoJobs.Domain.Queries.Experiences;
using InfoJobs.Shared.Handlers.Contracts;
using InfoJobs.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoJobs.Domain.Handlers.Experiences
{
    public class SearchExperienceByIdHandle : Notifiable<Notification>, IHandlerQuery<SearchExperienceByIdQuery>
    {
        private readonly IExperienceRepository _experienceRepository;

        public SearchExperienceByIdHandle(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public IQueryResult Handler(SearchExperienceByIdQuery query)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new GenericQueryResult(false, "Correctly enter experience data", query.Notifications);
            }

            var searchedExperience = _experienceRepository.SearchById(query.Id);

            if (searchedExperience == null)
            {
                return new GenericQueryResult(false, "Experience not found", query.Notifications);
            }

            return new GenericQueryResult(true, "Experience found!", searchedExperience);
        }
    }
}
