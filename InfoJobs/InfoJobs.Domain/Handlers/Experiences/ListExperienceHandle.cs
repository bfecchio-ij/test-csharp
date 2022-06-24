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
    public class ListExperienceHandle : Notifiable<Notification>, IHandlerQuery<ListExperienceQuery>
    {
        private readonly IExperienceRepository _experienceRepository;

        public ListExperienceHandle(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public IQueryResult Handler(ListExperienceQuery query)
        {
            var list = _experienceRepository.List();

            return new GenericQueryResult(true, "Experiences found!", list);
        }
    }
}
