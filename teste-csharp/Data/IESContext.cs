using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using teste_csharp.Models;

namespace teste_csharp.Data
{
    public class IESContext : DbContext
    {
        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {
           
        }
        public DbSet<Candidate> candidates { get; set; }
        public DbSet<CandidateExperience> candidateExperiences { get; set; }

    }

}

