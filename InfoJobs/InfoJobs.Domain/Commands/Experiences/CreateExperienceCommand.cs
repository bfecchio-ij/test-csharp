using Flunt.Notifications;
using Flunt.Validations;
using InfoJobs.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoJobs.Domain.Commands.Experiences
{
    public class CreateExperienceCommand : Notifiable<Notification>, ICommand
    {
        public CreateExperienceCommand() { }

        public CreateExperienceCommand(string company, string job, string description, decimal salary, DateTime beginDate, DateTime? endDate, Guid idCandidate)
        {
            Company = company;
            Job = job;
            Description = description;
            Salary = salary;
            BeginDate = new DateTime();
            EndDate = new DateTime();
            IdCandidate = idCandidate;
        }

        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid IdCandidate { get; set; }

        public void Validate()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Company, "Company", "The 'Company' field cannot be empty!")
                .IsNotEmpty(Job, "Job", "The 'Job' field cannot be empty!")
                .IsNotEmpty(Description, "Description", "The 'Description' field cannot be empty!")
                .IsNotNull(Salary, "Salary", "The 'Salary' field cannot be null!")
                .IsNotNull(BeginDate, "BeginDate", "The 'BeginDate' field cannot be null!")
                .IsNotNull(IdCandidate, "IdCandidates", "The 'IdCandidates' field cannot be null!")
            );
        }
    }
}
