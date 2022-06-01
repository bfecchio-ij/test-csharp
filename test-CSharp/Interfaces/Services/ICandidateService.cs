using test_CSharp.Models;

namespace test_CSharp.Interfaces
{
    public interface ICandidateService
    {
        Task<List<Candidate>> GetCandidatesAsync();
        Task<Candidate> GetCandidateByIdAsync(int id);
        Task AddCandidate(Candidate candidate);
        Task RemoveCandidate(int id);
        Task<Candidate> UpdateCandidate(Candidate candidate);
    }
}
