using InfoJobs.Domain.Interfaces;
using InfoJobs.Infra.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoJobs.Web.Controllers
{
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

        // Register a candidate:
        public IActionResult CreateCandidate()
        {
            return View();
        }

        //public IActionResult DeleteCandidate(Guid idCandidate)
        //{
        //    var searchedCandidate = _candidateRepository.SearchById(idCandidate);

        //    if (userFinded != null)
        //    {
        //        _candidateRepository.Delete(userFinded);
        //    }

        //    return LocalRedirect("~/Candidates/Index/");
        //}
    }
}
