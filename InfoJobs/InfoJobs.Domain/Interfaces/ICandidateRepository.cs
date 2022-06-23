using InfoJobs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoJobs.Domain.Interfaces
{
    public interface ICandidateRepository
    {
        // Commands:
        void Add(Candidate candidate);

        void Delete(Guid id);

        void Update(Candidate candidate);



        // Queries:
        IEnumerable<Candidate> List();

        Candidate SearchById(Guid id);

        Candidate SearchByEmail(string email);
    }
}
