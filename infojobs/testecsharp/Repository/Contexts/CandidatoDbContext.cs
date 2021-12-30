using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contexts
{
    public class CandidatoDbContext : DbContext
    {
        public CandidatoDbContext(DbContextOptions<CandidatoDbContext> options) : base(options)
        {

        }

        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<ExperienciaCandidato> ExperienciasCandidatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidato>().HasKey(c => c.IdCandidato);
            modelBuilder.Entity<Candidato>().HasAlternateKey(c => c.Email);
            modelBuilder.Entity<ExperienciaCandidato>().HasOne(p => p.Candidato).WithMany(b => b.Experiencias).HasForeignKey(p => p.IdCandidato);
        }
    }
}
