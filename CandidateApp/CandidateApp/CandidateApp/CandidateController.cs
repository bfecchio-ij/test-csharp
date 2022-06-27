using CandidateApp.Application.Commands.Candidate.Requests;
using CandidateApp.Application.Commands.Requests;
using CandidateApp.Application.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CandidateApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CandidateController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public IActionResult CreateCandidate([FromBody] CreateCandidateRequest request)
        {
            if (!ModelState.IsValid) return StatusCode(400);

            _mediator.Send(request);

            return StatusCode(201, "Candidate created");
        }

        [HttpPut]
        public IActionResult UpdateCandidate([FromBody] UpdateCandidateRequest request)
        {
            if (!ModelState.IsValid) return StatusCode(400);

            _mediator.Send(request);

            return StatusCode(200, "Candidate updated");
        }
    }
}
