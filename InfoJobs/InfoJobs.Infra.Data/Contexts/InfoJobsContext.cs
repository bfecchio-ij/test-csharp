using Flunt.Notifications;
using InfoJobs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoJobs.Infra.Data.Contexts
{
    public class InfoJobsContext : DbContext
    {
        public InfoJobsContext(DbContextOptions<InfoJobsContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> Experiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            #region Candidates
            // Adding Table Name
            modelBuilder.Entity<Candidate>().ToTable("Candidates");

            // Adding Id
            modelBuilder.Entity<Candidate>().Property(x => x.Id);

            // Adding Name
            modelBuilder.Entity<Candidate>().Property(x => x.Name).HasColumnType("VARCHAR(50)");
            modelBuilder.Entity<Candidate>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<Candidate>().Property(x => x.Name).IsRequired();

            // Adding Surname
            modelBuilder.Entity<Candidate>().Property(x => x.Surname).HasColumnType("VARCHAR(150)");
            modelBuilder.Entity<Candidate>().Property(x => x.Surname).HasMaxLength(150);
            modelBuilder.Entity<Candidate>().Property(x => x.Surname).IsRequired();

            // Adding BirthDate
            modelBuilder.Entity<Candidate>().Property(x => x.BirthDate).HasColumnType("DATE");

            // Adding Email
            modelBuilder.Entity<Candidate>().Property(x => x.Email).HasColumnType("VARCHAR(250)");
            modelBuilder.Entity<Candidate>().Property(x => x.Email).HasMaxLength(250);
            modelBuilder.Entity<Candidate>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<Candidate>().HasIndex(x => x.Email).IsUnique();

            // Adding InsertDate
            modelBuilder.Entity<Candidate>().Property(x => x.InsertDate).HasColumnType("DATETIME");
            modelBuilder.Entity<Candidate>().Property(x => x.InsertDate).HasDefaultValueSql("GETDATE()");

            // Adding ModifyDate
            modelBuilder.Entity<Candidate>().Property(x => x.ModifyDate).HasColumnType("DATETIME");
            modelBuilder.Entity<Candidate>().Property(x => x.ModifyDate).HasDefaultValueSql("GETDATE()");
            #endregion



            #region Experiences
            // Adding Table Name
            modelBuilder.Entity<CandidateExperience>().ToTable("Experiences");

            // Adding Id
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Id);

            // Adding Candidate's FK
            modelBuilder.Entity<CandidateExperience>()
                        .HasOne<Candidate>(x => x.Candidates)
                        .WithMany(x => x.Experiences)
                        .HasForeignKey(x => x.IdCandidate);

            // Adding Company
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Company).HasColumnType("VARCHAR(100)");
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Company).HasMaxLength(100);
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Company).IsRequired();

            // Adding Job
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Job).HasColumnType("VARCHAR(100)");
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Job).HasMaxLength(100);
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Job).IsRequired();

            // Adding Description
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Description).HasColumnType("VARCHAR(4000)");
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Description).HasMaxLength(4000);
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Description).IsRequired();

            // Adding Salary
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Salary).HasColumnType("NUMERIC(8,2)");
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Salary).IsRequired();

            // Adding BeginDate
            modelBuilder.Entity<CandidateExperience>().Property(x => x.BeginDate).HasColumnType("DATETIME");
            modelBuilder.Entity<CandidateExperience>().Property(x => x.BeginDate).IsRequired();

            // Adding EndDate
            modelBuilder.Entity<CandidateExperience>().Property(x => x.EndDate).HasColumnType("DATETIME");

            // Adding InsertDate
            modelBuilder.Entity<CandidateExperience>().Property(x => x.InsertDate).HasColumnType("DATETIME");
            modelBuilder.Entity<CandidateExperience>().Property(x => x.InsertDate).HasDefaultValueSql("GETDATE()");

            // Adding ModifyDate
            modelBuilder.Entity<CandidateExperience>().Property(x => x.ModifyDate).HasColumnType("DATETIME");
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
