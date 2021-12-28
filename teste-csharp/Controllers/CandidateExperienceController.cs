using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_csharp.Models;

namespace teste_csharp.Controllers
{
    public class CandidateExperienceController : Controller
    {
        public static IList<CandidateExperience> candidatesExperience = new List<CandidateExperience>()
        {
            new CandidateExperience()
            {
                IdCandidate = 1,
                Job = "Developer"
            }
        };
        // GET: CandidateExperienceController
        public ActionResult Index()
        {
            return View(candidatesExperience);
        }

        // GET: CandidateExperienceController/Details/5
        public ActionResult Details(int id)
        {
            return View(candidatesExperience.Where(x => x.IdCandidate == id).First());
        }

        // GET: CandidateExperienceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidateExperienceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CandidateExperience candidate)
        {
            try
            {
                candidatesExperience.Add(candidate);
                candidate.IdCandidate = candidatesExperience.Select(m => m.IdCandidate).Max() + 1;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidateExperienceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(candidatesExperience.Where(x => x.IdCandidate == id).First());
        }

        // POST: CandidateExperienceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidateExperienceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(candidatesExperience.Where(x => x.IdCandidate == id).First());
        }

        // POST: CandidateExperienceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
