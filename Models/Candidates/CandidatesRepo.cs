using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test_csharp.Models
{
    public class CandidatesRepo : DbContext
    {
        public CandidatesRepo(DbContextOptions<CandidatesRepo> options) : base(options)
        {

        }

        public DbSet<CandidatesModel> candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CandidatesModel>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<CandidatesModel>(
                eb =>
                {
                    eb.Property(b => b.Name).HasColumnType("varchar(50)");
                    eb.Property(b => b.Surname).HasColumnType("varchar(150)");
                    eb.Property(b => b.Birthdate).HasColumnType("datetime");
                    eb.Property(b => b.Email).HasColumnType("varchar(250)");
                    eb.Property(b => b.InsertDate).HasColumnType("datetime");
                    eb.Property(b => b.ModifyDate).HasColumnType("datetime");
                });
        }
    }
}
