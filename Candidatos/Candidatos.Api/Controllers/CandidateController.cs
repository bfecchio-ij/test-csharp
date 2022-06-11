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
            var c = _candidateAppService.GetAll();
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
            var c = _candidateAppService.GetById(id);
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
        public void Post([FromBody] Candidate value)
        {
            _candidateAppService.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Candidate value)
        {
            _candidateAppService.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _candidateAppService.Remove(_candidateAppService.GetById(id));
        }
    }
}
