using Microsoft.AspNetCore.Mvc;
using test_CSharp.Interfaces.Services;
using test_CSharp.Models;
using test_CSharp.Models.DTO;

namespace test_CSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateExperienceController : ControllerBase
    {
        private readonly ICandidateExperienceService _service;

        public CandidateExperienceController(ICandidateExperienceService service)
        {
            _service = service;
        }

        [HttpGet("{idCandidate}")]
        public async Task<ActionResult<List<CandidateExperience>>> GetExperiencesAsync(int idCandidate)
        {
            try
            {
                var experience = await _service.GetExperiencesAsync(idCandidate);
                return Ok(
                    experience.Select(
                        x => new
                        {
                            x.Company,
                            x.Job,
                            x.Description,
                            x.Salary,
                            x.BeginDate,
                            x.EndDate,
                            x.InsertDate,
                            x.ModifyDate
                        }));



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddExperience(CandidateExperienceDTO candidateExperience)
        {
            try
            {
                await _service.AddExperience(candidateExperience);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
