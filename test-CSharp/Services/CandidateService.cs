using test_CSharp.Interfaces;
using test_CSharp.Interfaces.Repositories;
using test_CSharp.Models;

namespace test_CSharp.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repository;
        private readonly ICandidateExperienceRepository _experienceRepository;

        public CandidateService(ICandidateRepository repository, ICandidateExperienceRepository experienceRepository)
        {
            _repository = repository;
            _experienceRepository = experienceRepository;
        }

        public async Task<List<Candidate>> GetCandidatesAsync()
        {
            var candidates = await _repository.GetCandidatesAsync();

            foreach (Candidate c in candidates)
                c.Experiences = await _experienceRepository.GetExperiencesAsync(c.IdCandidate);

            return candidates;
        }

        public async Task<Candidate> GetCandidateByIdAsync(int id)
        {
            var candidate = await _repository.GetCandidateByIdAsync(id);
            candidate.Experiences = await _experienceRepository.GetExperiencesAsync(candidate.IdCandidate);
            return candidate;
        }

        public async Task AddCandidate(Candidate candidate)
        {
            await _repository.AddCandidate(candidate);
            await _repository.SaveChangesAsync();
        }

        public async Task RemoveCandidate(int id)
        {
            var candidate = await _repository.GetCandidateByIdAsync(id);
            if (candidate == null)
                throw new DirectoryNotFoundException("Candidate not found");

            await _repository.RemoveCandidate(candidate);
            await _repository.SaveChangesAsync();

        }

        public async Task<Candidate> UpdateCandidate(Candidate candidate)
        {
            var candidateToUpdate = await _repository.GetCandidateByIdAsync(candidate.IdCandidate);
            if (candidateToUpdate == null)
                throw new DirectoryNotFoundException("Candidate not found");

            candidateToUpdate.Name = candidate.Name;
            candidateToUpdate.Surname = candidate.Surname;
            candidateToUpdate.Email = candidate.Email;
            candidateToUpdate.ModifyDate = DateTime.Now;

            await _repository.UpdateCandidate(candidateToUpdate);
            await _repository.SaveChangesAsync();

            return candidateToUpdate;
        }
    }
}
