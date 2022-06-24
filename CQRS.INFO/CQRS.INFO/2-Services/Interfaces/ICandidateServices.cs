using CQRS.INFO.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.INFO.Services.Interfaces
{
    public interface ICandidateServices
    {
        Task<IEnumerable<Candidate>> GetListOfCandidates();
        Task<Candidate> GetCandidateById(int id);
        Task<Candidate> CreateCandidate(Candidate candidate);
        Task<int> UpdateCandidate(Candidate candidate);
        Task<int> DeleteCandidate(Candidate candidate);
        Task<Candidate> CheckIfEmailIsUnique(string email);
    }
}
