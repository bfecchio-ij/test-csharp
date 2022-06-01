using test_CSharp.Interfaces;
using test_CSharp.Interfaces.Repositories;
using test_CSharp.Models;

namespace test_CSharp.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repository;

        public CandidateService(ICandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Candidate>> GetCandidatesAsync()
        {
            return await _repository.GetCandidatesAsync();
        }
    }
}
