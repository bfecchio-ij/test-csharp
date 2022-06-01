using test_CSharp.Interfaces.Repositories;
using test_CSharp.Interfaces.Services;
using test_CSharp.Models;
using test_CSharp.Models.DTO;

namespace test_CSharp.Services
{
    public class CandidateExperienceService : ICandidateExperienceService
    {
        private readonly ICandidateExperienceRepository _repository;

        public CandidateExperienceService(ICandidateExperienceRepository repository)
        {
            _repository = repository;
        }
        public async Task AddExperience(CandidateExperienceDTO experienceDTO)
        {
            var experience = new CandidateExperience
            {
                IdCandidate = experienceDTO.IdCandidate,
                Company = experienceDTO.Company,
                Job = experienceDTO.Job,
                Description = experienceDTO.Description,
                Salary = experienceDTO.Salary,
                BeginDate = experienceDTO.BeginDate,
                EndDate = experienceDTO.EndDate,
                InsertDate = experienceDTO.InsertDate,
                ModifyDate = experienceDTO.ModifyDate,
            };

            await _repository.AddExperience(experience);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<CandidateExperience>> GetExperiencesAsync(int idCandidate)
        {
            return await _repository.GetExperiencesAsync(idCandidate);
        }
    }
}
