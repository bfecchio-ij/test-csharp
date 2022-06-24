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
    public class UpdateCandidateCommand : Notifiable<Notification>, ICommand
    {
        public UpdateCandidateCommand() { }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public DateTime ModifyDate { get; set; }

        public void Validate()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Id, "Id", "The 'Id' field cannot be empty!")
                .IsNotEmpty(Name, "Name", "The 'Name' field cannot be empty!")
                .IsNotEmpty(Surname, "Surname", "The 'Surname' field cannot be empty!")
                .IsNotNull(BirthDate, "BirthDate", "The 'BirthDate' field cannot be null!")
                .IsEmail(Email, "Email", "Enter a valid email address!")
            );
        }
    }
}
