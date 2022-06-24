using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CQRS.INFO.Models.Data;
using CQRS.INFO.Models.Entities;
using CQRS.INFO.Commands.ExperienceCommands;
using CQRS.INFO.Queries.CandidateQueries;
using CQRS.INFO.Queries.ExperienceQueries;
using CQRS.INFO.Services.Interfaces;
using MediatR;

namespace CQRS.INFO.Controllers
{
    public class CandidatesExperienceController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMediator _mediator;
        private readonly ICandidateServices _candidateService;

        public CandidatesExperienceController(IMediator mediator, ApplicationContext context,
            ICandidateServices candidateService)
        {
            _mediator = mediator;
            _context = context;
            _candidateService = candidateService;
        }

        // GET: CandidatesExperience
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllExperiencesQuery()));
        }

        // GET: CandidatesExperience/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _mediator.Send(new GetExperienceByIdQuery()
            {
                Id = id

            }));
        }

        // GET: CandidatesExperience/Create
        public IActionResult Create()
        {
            LoadViewBags();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateExperienceCommand experienceCommand)
        {
            LoadViewBags();
            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(experienceCommand);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return View(experienceCommand);
        }

        // GET: CandidatesExperience/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            LoadViewBags();
            return View(await _mediator.Send(new GetExperienceByIdQuery()
            {
                Id = id
            }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CandidateExperience candidateExperience)
        {
            LoadViewBags();

            if (ModelState.IsValid && candidateExperience.BeginDate < candidateExperience.EndDate)
            {
                try
                {
                    _context.Update(candidateExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExperienceExists(candidateExperience.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Id", candidateExperience.CandidateId);
            return View(candidateExperience);
        }

        // GET: CandidatesExperience/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteExperienceCommand()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to delete. ");
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExperienceExists(int id)
        {
            return _context.CandidatesExperiences.Any(e => e.Id == id);
        }
        public void LoadViewBags()
        {
            ViewBag.Candidates = _context.Candidates;
        }
    }
}
