using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_csharp.Data;
using teste_csharp.Models;

namespace teste_csharp.Controllers
{
    public class CandidateController : Controller
    {
        private IESDbInitializer Initializer = new IESDbInitializer();
        // GET: CandidateController
        public ActionResult Index()
        {
            return View(Initializer);
        }

        // GET: CandidateController/Details/5
        public ActionResult Details(int id)
        {
            return View(Initializer);
        }

        // GET: CandidateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Candidate candidate)
        {
            try
            {
                //context.Candidates.Add(candidate);
                //candidate.IdCandidate = context.Candidates.Select(m => m.IdCandidate).Max() + 1;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Initializer);
        }

        // POST: CandidateController/Edit/5
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

        // GET: CandidateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Initializer);
        }

        // POST: CandidateController/Delete/5
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
