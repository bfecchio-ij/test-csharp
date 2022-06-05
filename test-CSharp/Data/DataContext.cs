using Microsoft.EntityFrameworkCore;
using test_CSharp.Models;

namespace test_CSharp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidateExperiences { get; set; }

    }
}
