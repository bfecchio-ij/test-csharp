using test_CSharp.Data;
using test_CSharp.Interfaces.Repositories;
using test_CSharp.Models;

namespace test_CSharp.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly DataContext _context;
        public CandidateRepository(DataContext context)
        {
            _context = context;
        }

        public List<Candidate> GetCandidates()
        {
            return new List<Candidate>
            {
                new Candidate
                {
                    Email="Marcello@email.com",
                    IdCandidate=1,
                    InsertDate = DateTime.Now,
                    ModifyDate = null,
                    Name= "Marcello",
                    Surname="Bronzatti" }
            };
        }
    }
}
