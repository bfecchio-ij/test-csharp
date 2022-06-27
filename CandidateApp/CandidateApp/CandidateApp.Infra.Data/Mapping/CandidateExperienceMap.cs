using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateApp.Infra.Data.Mapping
{
    public class CandidateExperienceMap : IEntityTypeConfiguration<Domain.Entities.CandidateExperience>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.CandidateExperience> builder)
        {
            builder.ToTable("CandidateExperiences");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Company).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Job).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(4000).IsRequired();
            builder.Property(t => t.Salary).HasColumnType("numeric(8, 2)").IsRequired();
            builder.Property(t => t.BeginDate).HasColumnType("datetime").IsRequired();
            builder.Property(t => t.EndDate).HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.InsertDate).HasColumnType("datetime").IsRequired();
            builder.Property(t => t.ModifyDate).HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.CandidateId).HasMaxLength(50).IsRequired();
        }
    }
}
