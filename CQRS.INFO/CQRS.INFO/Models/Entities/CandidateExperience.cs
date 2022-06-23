using CQRS.INFO.Models.Entities.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CQRS.INFO.Models.Entities
{
    public class CandidateExperience : Entity
    {
        public int Id { get; set; }
        public virtual Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public CandidateExperience() { }

        public CandidateExperience(int candidateId, string company, string job, string description,
            decimal salary, DateTime beginDate, DateTime endDate)
        {
            CandidateId = candidateId;
            Company = company;
            Job = job;
            Description = description;
            Salary = salary;
            BeginDate = beginDate;
            EndDate = endDate;
        }

        public void Configure(EntityTypeBuilder<CandidateExperience> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.CandidateId).IsRequired();
        }
    }
}
