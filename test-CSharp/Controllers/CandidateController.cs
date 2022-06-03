using Microsoft.AspNetCore.Mvc;
using test_CSharp.Interfaces;
using test_CSharp.Interfaces.Services;
using test_CSharp.Models;

namespace test_CSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _service;

        public CandidateController(ICandidateService service, ICandidateExperienceService experienceService)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Candidate>>> GetCandidatesAsync()
        {
            try
            {
                var candidates = await _service.GetCandidatesAsync();
                return Ok(
                    candidates.Select(x => new
                    {
                        x.IdCandidate,
                        x.Name,
                        x.Surname,
                        x.Email,
                        x.InsertDate,
                        x.ModifyDate,
                        Experiences = x.Experiences.Select(x => new
                        {
                            x.Company,
                            x.Job,
                            x.Description,
                            x.Salary,
                            x.BeginDate,
                            x.EndDate,
                            x.InsertDate,
                            x.ModifyDate

                        })
                    }));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Candidate>>> GetCandidateByIdAsync(int id)
        {
            try
            {
                var candidate = await _service.GetCandidateByIdAsync(id);

                if (candidate != null)
                {
                    return Ok(
                        new
                        {
                            candidate.IdCandidate,
                            candidate.Name,
                            candidate.Surname,
                            candidate.Email,
                            candidate.InsertDate,
                            candidate.ModifyDate,
                            Experiences = candidate.Experiences.Select(x => new
                            {
                                x.Company,
                                x.Job,
                                x.Description,
                                x.Salary,
                                x.BeginDate,
                                x.EndDate,
                                x.InsertDate,
                                x.ModifyDate
                            })
                        });
                }
                else
                    return BadRequest("Candidate not found");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddCandidate(Candidate candidate)
        {
            try
            {
                await _service.AddCandidate(candidate);
                return Ok("Candidate added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveCandidate(int id)
        {
            try
            {
                await _service.RemoveCandidate(id);
                return Ok(new
                {
                    Message = "Candidate Removed Successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Candidate>> UpdateCandidate(Candidate candidate)
        {
            try
            {
                await _service.UpdateCandidate(candidate);

                return Ok(candidate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
