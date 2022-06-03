using test_CSharp.Interfaces.Repositories;
using test_CSharp.Interfaces.Services;
using test_CSharp.Models;
using test_CSharp.Models.DTO;
using test_CSharp.Validators;

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
                ModifyDate = experienceDTO.ModifyDate
            };

            await _repository.AddExperience(experience);
            await _repository.SaveChangesAsync();

        }

        public async Task RemoveExperienceAsync(int idCandidate)
        {
            var candidate = await _repository.GetExperienceByIdAsync(idCandidate);
            if (candidate == null)
                throw new DirectoryNotFoundException("Experience not found");

            await _repository.RemoveExperienceAsync(candidate);
            await _repository.SaveChangesAsync();
        }

        public async Task<CandidateExperience> GetExperienceByIdAsync(int idCandidate)
        {
            return await _repository.GetExperienceByIdAsync(idCandidate);
        }

        public async Task<List<CandidateExperience>> GetExperiencesAsync(int idCandidate)
        {
            return await _repository.GetExperiencesAsync(idCandidate);
        }

        public async Task UpdateExperienceAsync(CandidateExperienceDTO experience)
        {
            var experienceToUpdate = await _repository.GetExperienceToUpdateAsync(experience.IdCandidateExperience, experience.IdCandidate);
            if (experienceToUpdate == null)
                throw new DirectoryNotFoundException("Experience not found");

            experienceToUpdate.Company = string.IsNullOrEmpty(experience.Company) ? experienceToUpdate.Company : experience.Company;
            experienceToUpdate.Job = string.IsNullOrEmpty(experience.Job) ? experienceToUpdate.Job : experience.Job;
            experienceToUpdate.Description = string.IsNullOrEmpty(experience.Description) ? experienceToUpdate.Description : experience.Description;
            experienceToUpdate.Salary = experience.Salary == 0m ? experienceToUpdate.Salary : experience.Salary;
            experienceToUpdate.BeginDate = experience.BeginDate;
            experienceToUpdate.EndDate = experience.EndDate;
            experienceToUpdate.InsertDate = experience.InsertDate;
            experienceToUpdate.ModifyDate = experience.ModifyDate;

            await _repository.UpdateExperienceAsync(experienceToUpdate);
            await _repository.SaveChangesAsync();
        }
    }
}
