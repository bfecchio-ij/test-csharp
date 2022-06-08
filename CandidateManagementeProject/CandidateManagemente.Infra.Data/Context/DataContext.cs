using CandidateManagemente.Application.Queries;
using CandidateManagemente.Domain.Entities;
using CandidateManagemente.Infra.Data.MappingEntityConfig;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CandidateManagemente.Infra.Data;
public class DataContext : DbContext
{
   
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DataContext()
    {

    }

    public DbSet<Candidates> candidates { get; set; }
    public DbSet<Experiences> candidateexperience { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CandidatesMap());
        modelBuilder.ApplyConfiguration(new ExperiencesMap());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
            "Data Source=Caio_Coutinho;Initial Catalog=DB_CandidateManagemente;Integrated Security=True;MultipleActiveResultSets=False");
        }
    }

}
