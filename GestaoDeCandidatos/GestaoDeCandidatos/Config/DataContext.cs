using GestaoDeCandidatos.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeCandidatos.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidatesMap());
            modelBuilder.ApplyConfiguration(new CandidateExperienceMap());
        }

        public DbSet<Candidates> candidates { get; set; }
        public DbSet<CandidateExperiences> candidateexperience { get; set; }
    }
}
