using Flunt.Notifications;
using Flunt.Validations;
using InfoJobs.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoJobs.Domain.Queries.Experiences
{
    public class SearchExperienceByIdQuery : Notifiable<Notification>, IQuery
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

        public class SearchExperienceByIdResult
        {
            public Guid Id { get; set; }
            public string Company { get; set; }
            public string Job { get; set; }
            public string Description { get; set; }
            public decimal Salary { get; set; }
            public DateTime BeginDate { get; set; }
            public DateTime? EndDate { get; set; }
            public DateTime InsertDate { get; set; }
            public DateTime? ModifyDate { get; set; }
        }
    }
}
