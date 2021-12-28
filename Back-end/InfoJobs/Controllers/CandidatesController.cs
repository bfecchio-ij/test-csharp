using InfoJobs.Data.Repository;
using InfoJobs.Dtos;
using InfoJobs.Models;
using InfoJobs.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InfoJobs.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CandidatesController : ControllerBase
    {
        
        private readonly ICandidatesServices _service;

        public CandidatesController( ICandidatesServices service)
        {
          
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {

            try
            {
                var result = await _service.GetAllCandidatesAsync();

                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex.Message}");

            }
        }
        [HttpGet("{idCandidate:int}")]
        public async Task<IActionResult> GetCandidateAsyncById(int idCandidate)
        {

            try
            {
                var result = await _service.GetCandidateAsyncById(idCandidate);

                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex.Message}");

            }


        }

        [HttpPost]
        public async Task<IActionResult> PostCandidateAsync(CandidatesRequestDto candidateDto)
        {
            try
            {
                var result = await _service.PostCandidateAsync(candidateDto);

                return Created($"/api/v1/candidates", result);


            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }


        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCandidateAsyncById(int id, CandidatesRequestDto candidateDto)
        {
            try
            {


                var result = await _service.UpdateCandidateAsyncById(id, candidateDto);

                return Ok( result);

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


                var result = await _service.DeleteCandidateAsyncById(id);

                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
    }
}
