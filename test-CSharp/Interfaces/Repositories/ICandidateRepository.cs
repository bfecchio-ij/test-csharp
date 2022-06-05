using test_CSharp.Models;

namespace test_CSharp.Interfaces.Repositories
{
    public interface ICandidateRepository
    {
        Task<bool> EmailBeingUsed(string email);
        Task SaveChangesAsync();
        Task<List<Candidate>> GetCandidatesAsync();
        Task<Candidate> GetCandidateByIdAsync(int id);
        Task AddCandidate(Candidate candidate);
        Task RemoveCandidate(Candidate candidate);
        Task<Candidate> UpdateCandidate(Candidate candidate);
    }
}
