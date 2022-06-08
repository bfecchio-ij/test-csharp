using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoDeCandidatos.Models;
using GestaoDeCandidatos.Models.ViewModels;

namespace GestaoDeCandidatos.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly DataContext _context;

        public CandidatesController(DataContext context)
        {
            _context = context;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {

            List<Candidates> cand = _context.candidates.ToList();
            CandidatesViewModel empre = new CandidatesViewModel();
            empre.listCandidates= cand;
            return View(empre);
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.candidateexperience == null)
            {
                return NotFound();
            }

            var candidateExperiences = await _context.candidateexperience
                .Include(c => c.Experiences)
                .FirstOrDefaultAsync(m => m.IdCandidateExperience == id);
            if (candidateExperiences == null)
            {
                return NotFound();
            }

            return View(candidateExperiences);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            ViewData["IdCandidate"] = new SelectList(_context.candidates, "IdCandidate", "Email");
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCandidateExperience,IdCandidate,Company,Job,Description,Salary,BeginDate,EndDate,InsertDate,ModifyDate")] CandidateExperiences candidateExperiences)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidateExperiences);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCandidate"] = new SelectList(_context.candidates, "IdCandidate", "Email", candidateExperiences.IdCandidate);
            return View(candidateExperiences);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.candidateexperience == null)
            {
                return NotFound();
            }

            var candidateExperiences = await _context.candidateexperience.FindAsync(id);
            if (candidateExperiences == null)
            {
                return NotFound();
            }
            ViewData["IdCandidate"] = new SelectList(_context.candidates, "IdCandidate", "Email", candidateExperiences.IdCandidate);
            return View(candidateExperiences);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCandidateExperience,IdCandidate,Company,Job,Description,Salary,BeginDate,EndDate,InsertDate,ModifyDate")] CandidateExperiences candidateExperiences)
        {
            if (id != candidateExperiences.IdCandidateExperience)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidateExperiences);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExperiencesExists(candidateExperiences.IdCandidateExperience))
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
            ViewData["IdCandidate"] = new SelectList(_context.candidates, "IdCandidate", "Email", candidateExperiences.IdCandidate);
            return View(candidateExperiences);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.candidateexperience == null)
            {
                return NotFound();
            }

            var candidateExperiences = await _context.candidateexperience
                .Include(c => c.Experiences)
                .FirstOrDefaultAsync(m => m.IdCandidateExperience == id);
            if (candidateExperiences == null)
            {
                return NotFound();
            }

            return View(candidateExperiences);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.candidateexperience == null)
            {
                return Problem("Entity set 'DataContext.candidateexperience'  is null.");
            }
            var candidateExperiences = await _context.candidateexperience.FindAsync(id);
            if (candidateExperiences != null)
            {
                _context.candidateexperience.Remove(candidateExperiences);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExperiencesExists(int id)
        {
          return (_context.candidateexperience?.Any(e => e.IdCandidateExperience == id)).GetValueOrDefault();
        }
    }
}
