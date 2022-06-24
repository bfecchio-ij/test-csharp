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
    public class SearchCandidateByEmailQuery : Notifiable<Notification>, IQuery
    {
        public string Email { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsEmail(Email, "Email", "The 'Email' field cannot be empty!")
                );
        }

        public class SearchCandidateByEmailResult
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
