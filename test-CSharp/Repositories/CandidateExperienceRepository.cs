using test_CSharp.Interfaces.Repositories;

namespace test_CSharp.Repositories
{
    public class CandidateExperienceRepository : ICandidateExperienceRepository
    {
        private readonly DataContext _context;

        public CandidateExperienceRepository(DataContext context)
        {
            _context = context;
        }




    }
}
