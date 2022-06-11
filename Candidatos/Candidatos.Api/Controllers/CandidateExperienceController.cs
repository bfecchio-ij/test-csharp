using Candidatos.Api.DTO;
using Candidatos.Application.Interfaces;
using Candidatos.Domain.Entities._CandidateExperience;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidatos.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CandidateExperienceController: ControllerBase
    {
        private readonly ICandidateExperienceAppService _candidateAppService;

        public CandidateExperienceController(ICandidateExperienceAppService candidateAppService)
        {
            _candidateAppService = candidateAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<CandidateExperienceDTO> candidateExperienceDTO = new List<CandidateExperienceDTO>();
            var ce = await _candidateAppService.GetAllAsync();
            if (ce == null) return NoContent();
            
            foreach (var item in ce)
            {
                candidateExperienceDTO.Add(new CandidateExperienceDTO
                {
                    BeginDate = item.BeginDate,
                    EndDate = item.EndDate,
                    BirthDate = item.Candidate.BirthDate,
                    Surname = item.Candidate.Surname,
                    Name = item.Candidate.Name,
                    Company = item.Company,
                    Description = item.Description,
                    Email = item.Candidate.Email,
                    IdCandidate = item.Candidate.IdCandidate,
                    Job = item.Job,
                    Salary = item.Salary,
                    IdCandidateExperience = item.IdCandidateExperience,
                });
            }
            return Ok(candidateExperienceDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ce = await _candidateAppService.GetByIdAsync(id);
            if (ce == null) return NoContent();
            
            var result = new CandidateExperienceDTO
            {
                BeginDate = ce.BeginDate,
                EndDate = ce.EndDate,
                BirthDate = ce.Candidate.BirthDate,
                Surname = ce.Candidate.Surname,
                Name = ce.Candidate.Name,
                Company = ce.Company,
                Description = ce.Description,
                Email = ce.Candidate.Email,
                IdCandidate = ce.Candidate.IdCandidate,
                Job = ce.Job,
                Salary = ce.Salary,
                IdCandidateExperience = ce.IdCandidateExperience,
            };

            return Ok(result);
        }

        [HttpPost]
        public async void Post([FromBody] CandidateExperience value)
        {
            await _candidateAppService.AddAsync(value);
        }

        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] CandidateExperience value)
        {
            await _candidateAppService.UpdateAsync(value);
        }

        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _candidateAppService.RemoveAsync(await _candidateAppService.GetByIdAsync(id));
        }
    }
}
