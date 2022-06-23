using CQRS.INFO.Models.Entities.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace CQRS.INFO.Models.Entities
{
    public class Candidate : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Entre com um email válido")]
        public string Email { get; set; }

        public Candidate() { }

        public Candidate(string name, string surname, DateTime birthDate, string email)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Email = email;
        }

        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Email).IsRequired();
        }
    }
}
