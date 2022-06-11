using Candidatos.Api.DTO;
using Candidatos.Application.Interfaces;
using Candidatos.Domain.Entities._Candidate;
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
        private readonly ICandidateAppService _candidateAppService;

        public CandidateController(ICandidateAppService candidateAppService)
        {
            _candidateAppService = candidateAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<CandidateDTO> candidatesDTO = new List<CandidateDTO>();
            var c = await _candidateAppService.GetAllAsync();
            if (c == null) return NoContent();
            
            foreach (var item in c)
            {
                candidatesDTO.Add(new CandidateDTO
                {
                    IdCandidate = item.IdCandidate,
                    Name = item.Name,
                    Email = item.Email,
                    Surname = item.Surname,
                    BirthDate = item.BirthDate,
                });
            }
            
            return Ok(candidatesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var c = await _candidateAppService.GetByIdAsync(id);
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

        [HttpPost]
        public async void Post([FromBody] Candidate value)
        {
            await _candidateAppService.AddAsync(value);
        }

        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] Candidate value)
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
