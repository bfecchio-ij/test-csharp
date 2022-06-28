using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CandidateApp.Domain.Entities;

namespace CandidateApp.Domain.Interfaces
{
    public interface ICandidateRepository : IRepository<Candidate>
    {
        Candidate Get(Guid id);

        IEnumerable<Candidate> GetAll();

    }
}
