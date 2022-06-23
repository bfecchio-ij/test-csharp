using Flunt.Notifications;
using Flunt.Validations;
using InfoJobs.Domain.Entities;
using InfoJobs.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoJobs.Domain.Queries.Candidates
{
    public class SearchCandidateByIdQuery : Notifiable<Notification>, IQuery
    {
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "The 'Id' field cannot be empty!")
                );
        }

        public class SearchCandidateByIdResult
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime BirthDate { get; set; }
            public string Email { get; set; }
            public DateTime InsertDate { get; set; }
            public DateTime? ModifyDate { get; set; }

            // Compositions
            public IReadOnlyCollection<CandidateExperience> Experiences { get; private set; }
            private List<CandidateExperience> _experiences { get; set; }
        }
    }
}
