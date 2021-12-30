using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using testecsharp.Models;
using Repository;
using Repository.Contexts;
using Microsoft.AspNetCore.Routing;

namespace testecsharp.Controllers
{
    public class CandidatoesController : Controller
    {
        private readonly CandidatoDbContext _context;

        public CandidatoesController(CandidatoDbContext context)
        {
            _context = context;
        }

        // GET: Candidatoes
        public async Task<IActionResult> Index(bool msgSucesso = false)
        {
            var candidatos = await new CandidatoRepository().GetCandidatos(_context);

            if (msgSucesso)
            {
                ViewBag.Sucesso = "informações salvas com sucesso";
            }

            return View(Mapear(candidatos));
        }

        // GET: Candidatoes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            var candidato = await new CandidatoRepository().GetCandidato(_context, id);

            if (candidato == null)
            {
                return NotFound();
            }

            return View(Mapear(candidato));
        }

        // GET: Candidatoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidatoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCandidato,Nome,Sobreome,Aniversario,Email,DataIngresso,DataUltimaAlteracao")] CandidatoViewModel candidato)
        {
            if (ModelState.IsValid)
            {
                var erro = await  new CandidatoRepository().SalvarCandidato(_context, Mapear(candidato));

                if (erro != null)
                {
                    ViewBag.Error = erro;
                }
                else
                {
                    return RedirectToAction(nameof(Index), new { msgSucesso = true });
                }
            }
            return View(candidato);
        }

        // GET: Candidatoes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            var candidato = await new CandidatoRepository().GetCandidato(_context, id);
            if (candidato == null)
            {
                return NotFound();
            }
            return View(Mapear(candidato));
        }

        // POST: Candidatoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdCandidato,Nome,Sobreome,Aniversario,Email,DataIngresso,DataUltimaAlteracao")] CandidatoViewModel candidato)
        {
            if (id != candidato.IdCandidato.ToString())
            {

                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var erro = await new CandidatoRepository().SalvarCandidato(_context, Mapear(candidato));

                if (erro != null)
                {
                    ViewBag.Error = erro;
                    return View(candidato);
                }
                else
                {
                    return RedirectToAction(nameof(Index), new { msgSucesso = true });
                }
                
            }
            return View(candidato);
        }

        // GET: Candidatoes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            var candidato = await new CandidatoRepository().GetCandidato(_context, id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(Mapear(candidato));
        }

        // POST: Candidatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var erro = await new CandidatoRepository().DeletarExperiencia(_context, id);

            if (erro != null)
            {
                ViewBag.Error = erro;
            }
            return RedirectToAction(nameof(Index), new { msgSucesso = true });
        }

        private Candidato Mapear(CandidatoViewModel viewModel)
        {
            var domain = new Candidato();

            domain.IdCandidato = viewModel.IdCandidato;
            domain.Nome = viewModel.Nome;
            domain.Sobreome = viewModel.Sobreome;
            domain.Email = viewModel.Email;
            domain.Aniversario = viewModel.Aniversario;
            domain.DataIngresso = viewModel.DataIngresso;
            domain.DataUltimaAlteracao = viewModel.DataUltimaAlteracao;

            return domain;
        }

        private CandidatoViewModel Mapear(Candidato domain)
        {
            var viewModel = new CandidatoViewModel();

            viewModel.IdCandidato =         domain.IdCandidato;
            viewModel.Nome =                domain.Nome;
            viewModel.Sobreome =            domain.Sobreome;
            viewModel.Email =               domain.Email;
            viewModel.Aniversario =         domain.Aniversario;
            viewModel.DataIngresso =        domain.DataIngresso;
            viewModel.DataUltimaAlteracao = domain.DataUltimaAlteracao;

            return viewModel;
        }

        private IEnumerable<CandidatoViewModel> Mapear(IEnumerable<Candidato> task)
        {
            var viewModelList = new List<CandidatoViewModel>();

            foreach (var item in task)
            {
                viewModelList.Add(Mapear(item));
            }
            IEnumerable<CandidatoViewModel> viewModelListIEnum = viewModelList;

            return viewModelListIEnum;
        }
    }
}
