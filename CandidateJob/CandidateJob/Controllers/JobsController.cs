using CandidateJob.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CandidateJob.Controllers
{
    public class JobsController : Controller
    {
        private readonly Context _context;

        public JobsController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Jobs(int? id)
        {
            var jobs = await _context.Job.Where(a => a.IdCandidate == id).ToListAsync();
            return View(jobs);
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult>CreateExperience(Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Jobs));
            }
            else return View(job);
        }

        [HttpGet]
        public IActionResult UpdateJob(int? id)
        {
            if (id != null)
            {
                Job job = _context.Job.Find(id);
                return View(job);
            }
            else return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateJob(int? id, Job job)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Jobs));
                }
                else return View(job);
            }
            else return NotFound();
        }

        [HttpGet]
        public IActionResult DeleteJob(int? id)
        {
            if (id != null)
            {
                Job job = _context.Job.Find(id);
                return View(job);
            }
            else return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> DeleteJob(int? id, Job job)
        {
            if (id != null)
            {
                _context.Remove(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Jobs));
            }
            else return NotFound();
        }

    }
}
