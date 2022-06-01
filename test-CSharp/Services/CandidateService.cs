using test_CSharp.Interfaces;
using test_CSharp.Interfaces.Repositories;

namespace test_CSharp.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repository;

        public CandidateService(ICandidateRepository repository)
        {
            _repository = repository;
        }



    }
}
