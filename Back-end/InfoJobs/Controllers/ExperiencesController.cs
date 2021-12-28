using InfoJobs.Data.Repository;
using InfoJobs.Dtos;
using InfoJobs.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InfoJobs.Controllers
{
    [EnableCors]

    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ExperiencesController : ControllerBase
    {
        
        private readonly ICandidateExperiencesServices _service;

       
        public ExperiencesController(ICandidateExperiencesServices service)
        {

            this._service = service;

            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExperiences()
        {

            try
            {

                var result = await _service.GetAllExperiences();

                return Ok(result);



            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }


        [HttpGet("candidate/{idCandidate:int}")]
        public async Task<IActionResult> GetExperienceByCandidatesId(int idCandidate)
        {

            try
            {
                var result = await _service.GetExperienceAsyncByCandidateId(idCandidate);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetExperienceAsyncById(int id)
        {

            try
            {

                var result = await _service.GetExperienceAsyncById(id);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        public async Task<IActionResult> PostExperienceAsync(CandidateExperiencesRequestDto experienceDto)
        {
            try
            {
                var result = await _service.PostExperienceAsync(experienceDto);

                return Created($"/api/v1/candidates", result);


            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }


        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCandidateExperiencesAsyncById(int id, CandidateExperiencesRequestDto candidateDto)
        {
            try
            {


                var result = await _service.UpdateCandidateExperienceAsyncById(id, candidateDto);

                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteCandidateAsyncById(int id)
        {

            try
            {


                var result = await _service.DeleteCandidateExperienceAsyncById(id);

                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

    }
}
