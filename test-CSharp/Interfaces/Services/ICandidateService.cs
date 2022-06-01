using test_CSharp.Models;

namespace test_CSharp.Interfaces
{
    public interface ICandidateService
    {
        Task<List<Candidate>> GetCandidatesAsync();
        Task<Candidate> GetCandidateByIdAsync(int id);
        Task AddCandidate(Candidate candidate);
    }
}
