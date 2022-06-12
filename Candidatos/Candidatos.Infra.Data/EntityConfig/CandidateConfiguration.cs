using Candidatos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Candidatos.Infra.Data.EntityConfig
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(c => c.IdCandidate);
            builder.Property(c => c.IdCandidate).ValueGeneratedOnAdd();

            builder.HasAlternateKey(c => c.Email);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(250);
            builder.Property(c => c.BirthDate).IsRequired();

            builder.Property(c => c.InsertDate).IsRequired().HasDefaultValueSql("getDate()");

            // Relationships
            builder.HasMany(c => c.CandidateExperiences).WithOne(cs => cs.Candidate).HasForeignKey(cs => cs.IdCandidate);
        }
    }
}
