﻿using Candidatos.Domain.Entities;
using Candidatos.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Candidatos.Infra.Data.Context
{
    public class JobContext : DbContext
    {
        public JobContext()
        {

        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidateExperiences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(BuildConnectionString(".", "CandidatesDb"));
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
            modelBuilder.ApplyConfiguration(new CandidateExperienceConfiguration());
        }

        protected string BuildConnectionString(string instanceSQL, string DabaseName)
        {
            return $"Data Source={instanceSQL};Initial Catalog={DabaseName};Trusted_Connection=True;";
        }
    }
}