using GestaoDeCandidatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeCandidatos.Mapping
{
    public class CandidatesMap : IEntityTypeConfiguration<Candidates>
    {
        public void Configure(EntityTypeBuilder<Candidates> builder)
        {
            builder.ToTable("candidates");

            builder.HasKey(p => p.IdCandidate);
            builder.Property(p => p.Name).HasColumnType("varchar(50)");
            builder.Property(p => p.Surname).HasColumnType("varchar(150)");
            builder.Property(p => p.Birthdate).HasColumnType("datetime");
            builder.Property(p => p.Email).HasColumnType("varchar(250)");
            builder.Property(p => p.InsertDate).HasColumnType("datetime");
            builder.Property(p => p.ModifyDate).HasColumnType("datetime");
            builder.HasAlternateKey(p => p.Email);
            
        }
    }
}
