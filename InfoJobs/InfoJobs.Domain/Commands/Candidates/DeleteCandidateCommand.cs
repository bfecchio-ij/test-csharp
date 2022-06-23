using Flunt.Notifications;
using Flunt.Validations;
using InfoJobs.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoJobs.Domain.Commands.Candidates
{
    public class DeleteCandidateCommand : Notifiable<Notification>, ICommand
    {
        public DeleteCandidateCommand() { }

        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
            new Contract<Notification>()
                   .Requires()
                   .IsNotEmpty(Id, "Id", "The 'Id' field cannot be empty!")
            );
        }
    }
}
