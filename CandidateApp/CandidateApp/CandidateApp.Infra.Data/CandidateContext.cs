using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using CandidateApp.Domain.Entities;
using CandidateApp.Infra.Data.Mapping;

namespace CandidateApp.Infra.Data
{
    public class CandidateDBContext : DbContext
    {
        
        public CandidateDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Domain.Entities.Candidate> Candidates { get; set; }

        public DbSet<Domain.Entities.CandidateExperience> CandidateExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CandidateMap());

            modelBuilder.ApplyConfiguration(new CandidateExperienceMap());
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging()
                          .UseSqlServer(@"Server=(local);Database=CandidateDb;User Id = sa;Password=testE12@12;MultipleActiveResultSets=true");
        }

    }
}
