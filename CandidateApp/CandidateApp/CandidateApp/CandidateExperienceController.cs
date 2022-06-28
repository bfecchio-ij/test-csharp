using CandidateApp.Application.Commands.Candidate.Requests;
using CandidateApp.Application.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateExperienceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CandidateExperienceController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public IActionResult CreateCandidateExperience([FromBody] CreateCandidateExperienceRequest request)
        {
            if (!ModelState.IsValid) return StatusCode(400);

            var command = _mediator.Send(request);

            if (!command.Result)
                return StatusCode(400, "Candidato não existe.");

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult UpdateCandidateExperience([FromBody] UpdateCandidateExperienceRequest request)
        {
            if (!ModelState.IsValid) return StatusCode(400);
            var command = _mediator.Send(request);
  
            if (!command.Result)
                return StatusCode(400, "Experiencia de candidato não existe.");
  
            return StatusCode(200, "Candidate updated");
        }
    }
}
