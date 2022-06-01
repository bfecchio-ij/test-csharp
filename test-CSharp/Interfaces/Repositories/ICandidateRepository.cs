using test_CSharp.Models;

namespace test_CSharp.Interfaces.Repositories
{
    public interface ICandidateRepository
    {
        Task SaveChangesAsync();
        Task<List<Candidate>> GetCandidatesAsync();
        Task<Candidate> GetCandidateByIdAsync(int id);
        Task AddCandidate(Candidate candidate);
    }
}
