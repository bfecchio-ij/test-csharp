using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CQRS.INFO.Models.Data;
using CQRS.INFO.Models.Entities;
using MediatR;
using CQRS.INFO.Services.Interfaces;
using CQRS.INFO.Queries.CandidateQueries;
using CQRS.INFO.Commands.CandidateCommands;

namespace CQRS.INFO.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        private readonly ICandidateServices _candidateService;

        public CandidatesController(IMediator mediator, ApplicationContext context, ICandidateServices candidateService)
        {
            _mediator = mediator;
            _context = context;
            _candidateService = candidateService;
        }

        // GET: Candidate
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllCandidatesQuery()));
        }

        // GET: Candidate/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _mediator.Send(new GetCandidateByIdQuery()
            {
                Id = id

            }));
        }

        // GET: Candidate/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCandidateCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(command);
        }

        // GET: Candidate/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _mediator.Send(new GetCandidateByIdQuery()
            {
                Id = id
            }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateCandidateCommand candidateCommand)
        {
            if (id != candidateCommand.Id)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(candidateCommand);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(candidateCommand);
        }

        // GET: Candidate/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteCandidateCommand()
                {
                    Id = id
                });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to delete. ");
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Candidate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidates.Any(e => e.Id == id);
        }
    }
}
