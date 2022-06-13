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
    public class CandidatesController : Controller
    {
        private readonly CandidatesRepo _context;

        public CandidatesController(CandidatesRepo context)
        {
            _context = context;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            return View(await _context.candidates.ToListAsync());
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatesModel = await _context.candidates
                .FirstOrDefaultAsync(m => m.IdCandidate == id);
            if (candidatesModel == null)
            {
                return NotFound();
            }

            return View(candidatesModel);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCandidate,Name,Surname,Birthdate,Email,InsertDate,ModifyDate")] CandidatesModel candidatesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidatesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidatesModel);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatesModel = await _context.candidates.FindAsync(id);
            if (candidatesModel == null)
            {
                return NotFound();
            }
            return View(candidatesModel);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCandidate,Name,Surname,Birthdate,Email,InsertDate,ModifyDate")] CandidatesModel candidatesModel)
        {
            if (id != candidatesModel.IdCandidate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatesModelExists(candidatesModel.IdCandidate))
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
            return View(candidatesModel);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatesModel = await _context.candidates
                .FirstOrDefaultAsync(m => m.IdCandidate == id);
            if (candidatesModel == null)
            {
                return NotFound();
            }

            return View(candidatesModel);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidatesModel = await _context.candidates.FindAsync(id);
            _context.candidates.Remove(candidatesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatesModelExists(int id)
        {
            return _context.candidates.Any(e => e.IdCandidate == id);
        }
    }
}
