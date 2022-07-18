using CandidateJob.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateJob.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly Context _context;

        public CandidatesController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidates.ToListAsync());
        }

        [HttpGet]
        public IActionResult CriarCandidato()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarCandidato(Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(candidate);
            }

        }

        [HttpGet]
        public IActionResult AtualizarCandidato(int? id)
        {
            if (id != null)
            {
                Candidate candidate = _context.Candidates.Find(id);
                return View(candidate);

            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarCandidato(int? id, Candidate candidate)
        {
            if(id != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Update(candidate);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else return View(candidate);
            }
            else return NotFound();
        }

        [HttpGet]
        public IActionResult ExcluirCandidato(int? id)
        {
            if (id != null)
            {
                Candidate candidate = _context.Candidates.Find(id);
                return View(candidate);

            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirCandidato(int? id, Candidate candidate)
        {
            if (id != null)
            {
                _context.Remove(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return NotFound();
        }

    }
}
