using Microsoft.EntityFrameworkCore;
using Projeto.Golnich.Domain.Candidatos;
using Projeto.Golnich.Domain.Experiencias;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Golnich.Infra
{
    public class Conexao : DbContext
    {
        public Conexao(DbContextOptions<Conexao> options) : base(options)
        {

        }
        public DbSet<Candidatos> Candidatos { get; set; }
        public DbSet<Experiencias> Experiencias { get; set; }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidatos>(entity =>
            {
                entity.HasKey(l => l.IdCandidato);

                entity.Property(l => l.Nome).HasMaxLength(50);
                entity.Property(l => l.Sobrenome).HasMaxLength(150);
                entity.Property(l => l.Email).HasMaxLength(250);
                entity.Property(l => l.DataCad).HasColumnType("datetime");
                entity.Property(l => l.DataAtu).HasColumnType("datetime");
                entity.Property(l => l.DataNascimento).HasColumnType("datetime");

            });
            modelBuilder.Entity<Experiencias>(entity =>
            {
                entity.HasKey(l => l.IdExperiencia);

                entity.HasOne(d => d.CandidatosNav)
                 .WithMany(p => p.Experiencias)
                 .HasForeignKey(d => d.IdCandidato);
                entity.Property(l => l.Empresa).HasMaxLength(100);
                entity.Property(l => l.Cargo).HasMaxLength(100);
                entity.Property(l => l.Descricao).HasMaxLength(4000);
                entity.Property(l => l.Salario).HasColumnType("decimal(18, 2)");
                entity.Property(l => l.DataInicio).HasColumnType("datetime");
                entity.Property(l => l.DataSaida).HasColumnType("datetime");
                entity.Property(l => l.DataCad).HasColumnType("datetime");
                entity.Property(l => l.DataAtu).HasColumnType("datetime");
                entity.Ignore(l => l.Nome_Candidato);
            });
        }
    }
}
