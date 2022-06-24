using InfoJobs.Domain.Commands.Experiences;
using InfoJobs.Domain.Handlers.Experiences;
using InfoJobs.Domain.Queries.Experiences;
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
    [Route("v1/experiences")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        // Commands:

        [Route("add")]
        [HttpPost]
        public GenericCommandResult AddExperience(CreateExperienceCommand command, [FromServices] CreateExperienceHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }


        [Route("delete")]
        [HttpDelete]
        public GenericCommandResult DeleteExperience(DeleteExperienceCommand command, [FromServices] DeleteExperienceHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }


        [Route("update")]
        [HttpPut]
        public GenericCommandResult UpdateExperience(UpdateExperienceCommand command, [FromServices] UpdateExperienceHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }



        // Queries:

        [Route("list")]
        [HttpGet]
        public GenericQueryResult ListExperiences([FromServices] ListExperienceHandle handle)
        {
            ListExperienceQuery query = new ListExperienceQuery();

            return (GenericQueryResult)handle.Handler(query);
        }


        [Route("searchId/{idExperience}")]
        [HttpGet]
        public GenericQueryResult SearchExperienceById(Guid idExperience, [FromServices] SearchExperienceByIdHandle handle)
        {
            var query = new SearchExperienceByIdQuery
            {
                Id = idExperience
            };

            return (GenericQueryResult)handle.Handler(query);
        }
    }
}
