using GestaoDeCandidatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeCandidatos.Mapping
{
    public class CandidateExperienceMap : IEntityTypeConfiguration<CandidateExperiences>
    {
        public void Configure(EntityTypeBuilder<CandidateExperiences> builder)
        {
            builder.ToTable("candidateexperiences");

            builder.HasKey(p => p.IdCandidateExperience);
            builder.Property(p => p.IdCandidate).HasColumnType("int");
            builder.Property(p => p.Company).HasColumnType("varchar(100)");
            builder.Property(p => p.Job).HasColumnType("varchar(100)");
            builder.Property(p => p.Description).HasColumnType("varchar(4000)");
            builder.Property(p => p.Salary).HasColumnType("numeric(8,2)");
            builder.Property(p => p.BeginDate).HasColumnType("datetime");
            builder.Property(p => p.EndDate).HasColumnType("datetime");
            builder.Property(p => p.InsertDate).HasColumnType("datetime");
            builder.Property(p => p.ModifyDate).HasColumnType("datetime");
            builder.HasOne(p => p.Experiences).WithMany().HasForeignKey(p=> p.IdCandidate);

        }
    }
}
