using InfoJobs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace InfoJobs.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Candidates> Candidates { get; set; } 
        public DbSet<CandidateExperiences> CandidateExperiences { get; set; }

       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            


            builder
                .Entity<Candidates>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired(true);


            builder
                .Entity<Candidates>()
                .Property(x => x.Email)
                .HasMaxLength(250)
                .IsRequired(true)
                .IsUnicode(true);
                

            builder
              .Entity<Candidates>()
              .Property(x => x.Surname)
              .HasMaxLength(150)
              .IsUnicode(false)
              .IsRequired(true);

            builder
              .Entity<CandidateExperiences>()
              .Property(x => x.Company)
              .HasMaxLength(100)
              .IsUnicode(false)
              .IsRequired(true);

            builder
              .Entity<CandidateExperiences>()
              .Property(x => x.Job)
              .HasMaxLength(100)
              .IsUnicode(false)
              .IsRequired(true);

            builder
              .Entity<CandidateExperiences>()
              .Property(x => x.Description)
              .HasMaxLength(4000)
              .IsUnicode(false)
              .IsRequired(true);


            //builder.Entity<Candidates>()
            //  .HasData(new List<Candidates>(){
            //        new Candidates(1,"João","joãodascouves@papainoel.com",new DateTime(2020,3,1,7,0,0 )),
            //        new Candidates(2,"Joãooo","joãodascouves@papainoel.com",new DateTime(2000,3,1,7,0,0 )),
            //      new Candidates(3,"Joãooo","joãodas123couves@papainoel.com",new DateTime(2000,3,1,7,0,0 ))

                   
            //  });


            //builder.Entity<CandidateExperiences>()
            //    .HasData(new List<CandidateExperiences>()
            //    {
            //        new CandidateExperiences(1, "InfoJobs", "Analista", "Analisar",1),

            //         new CandidateExperiences(2, "InfoJobs", "Analista", "Analisar",2)

            //    });


        }
    }
}