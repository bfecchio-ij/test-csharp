using test_CSharp.Data;
using test_CSharp.Interfaces.Repositories;

namespace test_CSharp.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly DataContext _context;
        public CandidateRepository(DataContext context)
        {
            _context = context;
        }


    }
}
