using CQRS.INFO.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CQRS.INFO.Models.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidatesExperiences { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().HasAlternateKey(_ => _.Email);
            modelBuilder.Entity<CandidateExperience>().Property(_ => _.Salary).HasColumnType<decimal>("decimal").HasPrecision(8, 2);
            //SEEDER

            //modelBuilder.Entity<Candidate>().HasData(new Candidate
            //{
            //    Id = 1,
            //    Name = "John",
            //    Surname = "Lee",
            //    BirthDate = new DateTime(2000, 01, 02),
            //    Email = "john@gmail.com"

            //});
            //modelBuilder.Entity<Candidate>().HasData(new Candidate
            //{
            //    Id = 2,
            //    Name = "Anne",
            //    Surname = "Moraes",
            //    BirthDate = new DateTime(1990, 08, 07),
            //    Email = "anne@gmail.com"

            //});
            //modelBuilder.Entity<CandidateExperience>().HasData(new CandidateExperience
            //{
            //    Id = 3,
            //    CandidateId = 1,
            //    Company = "Apple",
            //    Job = "Scrum master",
            //    Description = "specify and delegate tasks",
            //    Salary = new decimal(1888.2),
            //    BeginDate = new DateTime(2010, 02, 02),
            //    EndDate = new DateTime(2012, 05, 10)
            //});
            //modelBuilder.Entity<CandidateExperience>().HasData(new CandidateExperience
            //{
            //    Id = 4,
            //    CandidateId = 2,
            //    Company = "InfoJobs",
            //    Job = "Developer",
            //    Description = "Develop new solutions",
            //    Salary = new decimal(2800.2),
            //    BeginDate = new DateTime(2011, 02, 02),
            //    EndDate = new DateTime(2012, 05, 10)
            //});

        }
    }
}
