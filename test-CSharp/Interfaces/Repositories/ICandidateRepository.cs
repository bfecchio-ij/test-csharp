using test_CSharp.Models;

namespace test_CSharp.Interfaces.Repositories
{
    public interface ICandidateRepository
    {
        List<Candidate> GetCandidates();
    }
}
