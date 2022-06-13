using Candidatos.Application.DTO;
using Candidatos.Application.Interfaces;
using Candidatos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Candidatos.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateAppService)
        {
            _candidateService = candidateAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var c = await _candidateService.GetAllAsync();
            if (c == null) return NoContent();
            return Ok(c);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var c = await _candidateService.GetByIdAsync(id);
            if (c == null) return NoContent();

            var result = new CandidateDTO
            {
                IdCandidate = c.IdCandidate,
                Name = c.Name,
                Email = c.Email,
                Surname = c.Surname,
                BirthDate = c.BirthDate,
            };

            return Ok(result);
        }

        [HttpGet("byEmail/{email}")]
        public async Task<bool> Get(string email)
        {
            var c = await _candidateService.GetByEmail(email);
            return c;
        }

        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var c = await _candidateService.GetByIdWithExperiencesAsync(id);
            if (c == null) return NoContent();

            return Ok(c);
        }

        [HttpPost]
        public async void Post([FromBody] CandidateDTO value)
        {
            await _candidateService.CreateAsync(value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CandidateDTO value)
        {
            value.IdCandidate = id;
            var c = await _candidateService.GetByIdAsync(id);
            if (c == null) return NoContent();
            
            await _candidateService.UpdateAsync(value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var c = await _candidateService.GetByIdAsync(id);
            if (c == null) return NoContent();

            await _candidateService.RemoveAsync(id.Value);
            return Ok();
        }
    }
}
