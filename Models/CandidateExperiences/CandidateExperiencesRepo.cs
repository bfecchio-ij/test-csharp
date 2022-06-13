using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test_csharp.Models
{
    public class CandidateExperiencesRepo : DbContext
    {
        public CandidateExperiencesRepo(DbContextOptions<CandidateExperiencesRepo> options) : base(options)
        {

        }

        public DbSet<CandidateExperiencesModel> candidateexperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CandidateExperiencesModel>()
                .HasOne(p => p.CandidatesModel)
                .WithMany(b => b.CandidateExperiences);

            builder.Entity<CandidateExperiencesModel>(
                eb =>
                {
                    eb.Property(b => b.Company).HasColumnType("varchar(100)");
                    eb.Property(b => b.Job).HasColumnType("varchar(100)");
                    eb.Property(b => b.Description).HasColumnType("varchar(4000)");
                    eb.Property(b => b.Salary).HasColumnType("numeric(8,2)");
                    eb.Property(b => b.BeginDate).HasColumnType("datetime");
                    eb.Property(b => b.EndDate).HasColumnType("datetime");
                    eb.Property(b => b.InsertDate).HasColumnType("datetime");
                    eb.Property(b => b.ModifyDate).HasColumnType("datetime");
                });
        }
    }
}
