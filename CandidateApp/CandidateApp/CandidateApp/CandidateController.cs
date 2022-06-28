using CandidateApp.Application.Commands.Candidate.Requests;
using CandidateApp.Application.Commands.Requests;
using CandidateApp.Application.Commands.Responses;
using CandidateApp.Application.Querys.Candidate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult UpdateCandidate([FromBody] UpdateCandidateRequest request)
        {
            if (!ModelState.IsValid) return StatusCode(400);

            _mediator.Send(request);

            return StatusCode(200, "Candidate updated");
        }

        [HttpDelete]
        public IActionResult DeleteCandidate([FromBody] DeleteCandidateRequest request)
        {
            if (!ModelState.IsValid) return StatusCode(400);

            _mediator.Send(request);

            return StatusCode(200);
        }

        [HttpGet, Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var query = new GetCandidateRequest() { Id = id };
            var candidateViewModel = _mediator.Send(query);

            return Ok(candidateViewModel.Result);
        }

        [HttpGet, Route("getAll")]
        public IActionResult GetAll()
        {
            var query = new GetAllCandidatesRequest();
            var candidatesViewModel = _mediator.Send(query);

            return Ok(candidatesViewModel.Result);
        }
    }
}
