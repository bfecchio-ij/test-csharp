using InfoJobs.Domain.Commands.Candidates;
using InfoJobs.Domain.Commands.Experiences;
using InfoJobs.Domain.Entities;
using InfoJobs.Domain.Handlers.Candidates;
using InfoJobs.Domain.Handlers.Experiences;
using InfoJobs.Domain.Interfaces;
using InfoJobs.Infra.Data.Contexts;
using InfoJobs.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoJobs.Web.Controllers
{
    // localhost:XXXXX/InfoJobs
    public class InfoJobsController : Controller
    {
        private readonly InfoJobsContext _ctx;
        private ICandidateRepository _candidateRepository;
        private IExperienceRepository _experienceRepository;

        public InfoJobsController(InfoJobsContext ctx, ICandidateRepository candidateRepository, IExperienceRepository experienceRepository)
        {
            _ctx = ctx;
            _candidateRepository = candidateRepository;
            _experienceRepository = experienceRepository;
        }


        // Candidates' View & Methods:

        // localhost:XXXXX/InfoJobs/List
        public async Task<IActionResult> List()
        {
            return View(await ListCandidates());
        }

        public IActionResult RegisterCandidate()
        {
            return View();
        }


        public async Task<IActionResult> ViewCandidate(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = await _ctx.Candidates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidates == null)
            {
                return NotFound();
            }

            List<CandidateExperience> experience = _experienceRepository.SearchExperienceByCandidate(candidates.Id);

            if (experience != null && experience.Count != 0)
            {
                ViewBag.Experiences = experience;
            }

            return View(candidates);
        }


        public IActionResult DeleteCandidate(Guid? Id)
        {
            var userFinded = _candidateRepository.SearchById(Id);

            if (userFinded != null)
            {
                _candidateRepository.Delete(userFinded);
            }

            return LocalRedirect("~/InfoJobs/List/");
        }


        [HttpPost]
        public GenericCommandResult CreateCandidate(CreateCandidateCommand command, [FromServices] CreateCandidateHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [HttpPut]
        public GenericCommandResult UpdateCandidate(UpdateCandidateCommand command, [FromServices] UpdateCandidateHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        public async Task<List<Candidate>> ListCandidates()
        {
            return await _ctx.Candidates.ToListAsync();
        }



        // Experiences' View & Methods:

        public async Task<IActionResult> ViewExperience(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiences = await _ctx.Experiences.FirstOrDefaultAsync(m => m.Id == id);

            if (experiences == null)
            {
                return NotFound();
            }

            return View(experiences);
        }

        public IActionResult DeleteExperience(Guid? Id)
        {
            var experienceFinded = _experienceRepository.SearchById(Id);

            if (experienceFinded != null)
            {
                _experienceRepository.Delete(experienceFinded);
            }

            return LocalRedirect("~/InfoJobs/ViewCandidate/" + experienceFinded.IdCandidate);
        }


        public async Task<IActionResult> SearchCandidates(IFormCollection searchCandidates)
        {
            string email = searchCandidates["search"];

            var candidates = await _ctx.Candidates.Where(x => EF.Functions.Like(x.Email, $"%{email}%")).ToListAsync();

            ViewBag.searchCandidates = candidates;

            return View();
        }


        [HttpPost]
        public GenericCommandResult CreateExperience(CreateExperienceCommand command, [FromServices] CreateExperienceHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);

        }

        [HttpPut]
        public GenericCommandResult UpdateExperience(UpdateExperienceCommand command, [FromServices] UpdateExperienceHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

    }
}
