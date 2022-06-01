using test_CSharp.Models;

namespace test_CSharp.Interfaces
{
    public interface ICandidateService
    {
        Task<List<Candidate>> GetCandidatesAsync();
    }
}
