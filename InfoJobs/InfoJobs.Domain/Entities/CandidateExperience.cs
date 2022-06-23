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
    public class CandidateExperience : Base
    {
        public CandidateExperience(string company, string job, string description, decimal salary, DateTime beginDate, DateTime insertDate, Guid idCandidates)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(company, "Company", "The 'Company' field cannot be empty!")
                .IsNotEmpty(job, "Job", "The 'Job' field cannot be empty!")
                .IsNotEmpty(description, "Description", "The 'Description' field cannot be empty!")
                .IsNotNull(salary, "Salary", "The 'Salary' field cannot be null!")
                .IsNotNull(beginDate, "BeginDate", "The 'BeginDate' field cannot be null!")
                .IsNotNull(insertDate, "InsertDate", "The 'InsertDate' field cannot be null!")
                .IsNotNull(idCandidates, "IdCandidates", "The 'IdCandidates' field cannot be null!")
            );

            Company = company;
            Job = job;
            Description = description;
            Salary = salary;
            BeginDate = beginDate;
            InsertDate = insertDate;
            IdCandidates = idCandidates;
        }

        public string Company { get; private set; }
        public string Job { get; private set; }
        public string Description { get; private set; }
        public decimal Salary { get; private set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        // FK's
        public Guid IdCandidates { get; set; }
        public Candidate Candidates { get; set; }


        public void UpdateCompany(string company)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotNull(company, "Company", "The 'Company' field cannot be null!")
                .IsNotEmpty(company, "Company", "The 'Company' field cannot be empty!")
            );

            if (IsValid)
            {
                Company = company;
            }
        }

    }
}
