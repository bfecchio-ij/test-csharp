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
    public class UpdateCandidateNameCommand : Notifiable<Notification>, ICommand
    {
        public UpdateCandidateNameCommand() { }

        public Guid Id { get; set; }
        public string Email { get; set; }

        public void Validate()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Id, "Id", "The 'Id' field cannot be empty!")
                .IsEmail(Email, "Email", "Enter a valid email address!")
            );
        }
    }
}
