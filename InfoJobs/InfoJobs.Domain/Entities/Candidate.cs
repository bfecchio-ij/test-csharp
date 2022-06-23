using Flunt.Notifications;
using Flunt.Validations;
using InfoJobs.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoJobs.Domain.Entities
{
    public class Candidate : Base
    {
        public Candidate(string name, string surname, DateTime birthdate, string email, DateTime insertDate, DateTime modifyDate)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(name, "Name", "The 'Name' field cannot be empty!")
                .IsNotEmpty(surname, "Surname", "The 'Surname' field cannot be empty!")
                .IsNotNull(birthdate, "Birthdate", "The 'Birthdate' field cannot be null!")
                .IsEmail(email, "Email", "Enter a valid email address!")
                .IsNotNull(insertDate, "InsertDate", "The 'InsertDate' field cannot be null!")
            );

            if (IsValid)
            {
                Name = name;
                Surname = surname;
                Birthdate = birthdate;
                Email = email;
                InsertDate = DateTime.Now;
            }
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; private set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        // Compositions
        public IReadOnlyCollection<CandidateExperience> Experiences { get; private set; }
        private List<CandidateExperience> _experiences { get; set; }

        // Configs

        //public void RegisterExperience(CandidateExperience experience)
        //{
        //    if (IsValid)
        //    {
        //        _experiences.Add(experience);
        //    }
        //}

        public void UpdateEmail(string email)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsEmail(email, "Email", "Enter a valid email address!")
            );

            if (IsValid)
            {
                Email = email;
            }
        }

    }
}
