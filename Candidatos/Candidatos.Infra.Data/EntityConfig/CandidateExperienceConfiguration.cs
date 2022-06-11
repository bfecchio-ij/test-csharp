using Candidatos.Domain.Entities._CandidateExperience;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Candidatos.Infra.Data.EntityConfig
{
    public class
    CandidateExperienceConfiguration
    : IEntityTypeConfiguration<CandidateExperience>
    {
        public void Configure(EntityTypeBuilder<CandidateExperience> builder)
        {
            builder.HasKey(c => c.IdCandidateExperience);
            builder.Property(c => c.IdCandidateExperience).ValueGeneratedOnAdd();

            builder.Property(c => c.Company).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Job).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(4000);

            builder.Property(c => c.Salary).HasColumnType("decimal(8,2)");
            builder.Property(c => c.BeginDate).IsRequired();

            builder.Property(c => c.InsertDate).IsRequired().HasDefaultValueSql("getDate()");

            // Relationships
            builder.HasOne(c => c.Candidate).WithMany(cs => cs.CandidateExperiences).HasForeignKey(cs => cs.IdCandidate);
        }
    }
}
