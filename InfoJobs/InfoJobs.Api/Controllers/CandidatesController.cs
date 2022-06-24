using InfoJobs.Domain.Commands.Candidates;
using InfoJobs.Domain.Handlers.Candidates;
using InfoJobs.Domain.Queries.Candidates;
using InfoJobs.Shared.Commands;
using InfoJobs.Shared.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoJobs.Api.Controllers
{
    [Produces("application/json")]
    [Route("v1/candidates")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        // Commands:

        [Route("add")]
        [HttpPost]
        public GenericCommandResult AddCandidate(CreateCandidateCommand command, [FromServices] CreateCandidateHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }


        [Route("delete")]
        [HttpDelete]
        public GenericCommandResult DeleteCandidate(DeleteCandidateCommand command, [FromServices] DeleteCandidateHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }


        [Route("update")]
        [HttpPut]
        public GenericCommandResult UpdateCandidate(UpdateCandidateCommand command, [FromServices] UpdateCandidateHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }



        // Queries:

        [Route("list")]
        [HttpGet]
        public GenericQueryResult ListCandidates([FromServices] ListCandidateHandle handle)
        {
            ListCandidateQuery query = new ListCandidateQuery();

            return (GenericQueryResult)handle.Handler(query);
        }


        [Route("searchEmail/{email}")]
        [HttpGet]
        public GenericQueryResult SearchCandidateByEmail(string email, [FromServices] SearchCandidateByEmailHandle handle)
        {

            var query = new SearchCandidateByEmailQuery
            {
                Email = email
            };

            return (GenericQueryResult)handle.Handler(query);
        }


        [Route("searchId/{idCandidate}")]
        [HttpGet]
        public GenericQueryResult SearchCandidateById(Guid idCandidate, [FromServices] SearchCandidateByIdHandle handle)
        {
            var query = new SearchCandidateByIdQuery
            {
                Id = idCandidate
            };

            return (GenericQueryResult)handle.Handler(query);
        }
    }
}
