
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CandidateJob.Models
{
    public class Context: DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Job> Job { get; set; }

        public Context(DbContextOptions<Context> opcoes) : base(opcoes)
        {

        }
    }

}
