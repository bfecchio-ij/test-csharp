using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test_csharp.Models;

namespace test_csharp.Controllers
{
    public class CandidateExperiencesController : Controller
    {
        private readonly CandidateExperiencesRepo _context;

        public CandidateExperiencesController(CandidateExperiencesRepo context)
        {
            _context = context;
        }

        // GET: CandidateExperiences
        public async Task<IActionResult> Index()
        {
            return View(await _context.candidateexperiences.ToListAsync());
        }

        // GET: CandidateExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateExperiencesModel = await _context.candidateexperiences
                .FirstOrDefaultAsync(m => m.IdCandidateExperience == id);
            if (candidateExperiencesModel == null)
            {
                return NotFound();
            }

            return View(candidateExperiencesModel);
        }

        // GET: CandidateExperiences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CandidateExperiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCandidateExperience,IdCandidates,Company,Job,Description,Salary,BeginDate,EndDate,InsertDate,ModifyDate")] CandidateExperiencesModel candidateExperiencesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidateExperiencesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidateExperiencesModel);
        }

        // GET: CandidateExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateExperiencesModel = await _context.candidateexperiences.FindAsync(id);
            if (candidateExperiencesModel == null)
            {
                return NotFound();
            }
            return View(candidateExperiencesModel);
        }

        // POST: CandidateExperiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCandidateExperience,IdCandidates,Company,Job,Description,Salary,BeginDate,EndDate,InsertDate,ModifyDate")] CandidateExperiencesModel candidateExperiencesModel)
        {
            if (id != candidateExperiencesModel.IdCandidateExperience)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidateExperiencesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExperiencesModelExists(candidateExperiencesModel.IdCandidateExperience))
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
            return View(candidateExperiencesModel);
        }

        // GET: CandidateExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateExperiencesModel = await _context.candidateexperiences
                .FirstOrDefaultAsync(m => m.IdCandidateExperience == id);
            if (candidateExperiencesModel == null)
            {
                return NotFound();
            }

            return View(candidateExperiencesModel);
        }

        // POST: CandidateExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidateExperiencesModel = await _context.candidateexperiences.FindAsync(id);
            _context.candidateexperiences.Remove(candidateExperiencesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExperiencesModelExists(int id)
        {
            return _context.candidateexperiences.Any(e => e.IdCandidateExperience == id);
        }
    }
}
