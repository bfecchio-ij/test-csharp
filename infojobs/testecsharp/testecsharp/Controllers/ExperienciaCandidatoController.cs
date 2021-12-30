using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository.Contexts;
using Repository;
using testecsharp.Models;

namespace testecsharp.Controllers
{
    public class ExperienciaCandidatoController : Controller
    {
        private readonly CandidatoDbContext _context;

        public ExperienciaCandidatoController(CandidatoDbContext context)
        {
            _context = context;
        }

        // GET: Candidatoes
        public async Task<IActionResult> Index(bool msgSucesso = false)
        {
            var candidatos = await new ExperienciasCandidatosRepository().GetExperienciasCandidatos(_context);

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

            var candidato = await new ExperienciasCandidatosRepository().GetExperienciaCandidato(_context, id);

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
        public async Task<IActionResult> Create([Bind("IdExperienciaCandidato,IdCandidato,Empresa,Cargo,DescricaoCargo,Salario,DataIngresso,DataUltimaAlteracao,DataInicio,DateEncerramento")] ExperienciaCandidatoViewModel Experiencia)
        {
            if (ModelState.IsValid)
            {
                var erro = await new ExperienciasCandidatosRepository().SalvarCandidato(_context, Mapear(Experiencia));

                if (erro != null)
                {
                    ViewBag.Error = erro;
                }
                else
                {
                    return RedirectToAction(nameof(Index), new { msgSucesso = true });
                }
            }
            return View(Experiencia);
        }

        // GET: Candidatoes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            var candidato = await new ExperienciasCandidatosRepository().GetExperienciaCandidato(_context, id);
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
        public async Task<IActionResult> Edit(string id, [Bind("IdExperienciaCandidato,IdCandidato,Empresa,Cargo,DescricaoCargo,Salario,DataIngresso,DataUltimaAlteracao,DataInicio,DateEncerramento")] ExperienciaCandidatoViewModel experiencia)
        {
            if (id != experiencia.IdExperienciaCandidato.ToString())
            {

                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var erro = await new ExperienciasCandidatosRepository().SalvarCandidato(_context, Mapear(experiencia));

                if (erro != null)
                {
                    ViewBag.Error = erro;
                    return View(experiencia);
                }
                else
                {
                    return RedirectToAction(nameof(Index), new { msgSucesso = true });
                }

            }
            return View(experiencia);
        }

        // GET: Candidatoes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            var candidato = await new ExperienciasCandidatosRepository().GetExperienciaCandidato(_context, id);
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
            var erro = await new ExperienciasCandidatosRepository().DeletarExperiencia(_context, id);

            if (erro != null)
            {
                ViewBag.Error = erro;
            }
            return RedirectToAction(nameof(Index), new { msgSucesso = true });
        }

        private ExperienciaCandidato Mapear(ExperienciaCandidatoViewModel viewModel)
        {
            var domain = new ExperienciaCandidato();

            domain.IdExperienciaCandidato = viewModel.IdExperienciaCandidato;
            domain.IdCandidato = viewModel.IdCandidato;
            domain.Empresa = viewModel.Empresa;
            domain.Cargo = viewModel.Cargo;
            domain.DescricaoCargo = viewModel.DescricaoCargo;
            domain.Salario = viewModel.Salario;
            domain.DataInicio = viewModel.DataInicio;
            domain.DateEncerramento = viewModel.DateEncerramento;
            domain.DataIngresso = viewModel.DataIngresso;
            domain.DataUltimaAlteracao = viewModel.DataUltimaAlteracao;

            return domain;
        }

        private ExperienciaCandidatoViewModel Mapear(ExperienciaCandidato domain)
        {
            var viewModel = new ExperienciaCandidatoViewModel();

            viewModel.IdExperienciaCandidato = domain.IdExperienciaCandidato;
            viewModel.IdCandidato = domain.IdCandidato;
            viewModel.Empresa = domain.Empresa;
            viewModel.Cargo = domain.Cargo;
            viewModel.DescricaoCargo = domain.DescricaoCargo;
            viewModel.Salario = domain.Salario;
            viewModel.DataInicio = domain.DataInicio;
            viewModel.DataIngresso = domain.DataIngresso;
            viewModel.DateEncerramento = domain.DateEncerramento;
            viewModel.DataUltimaAlteracao = domain.DataUltimaAlteracao;

            return viewModel;
        }

        private IEnumerable<ExperienciaCandidatoViewModel> Mapear(IEnumerable<ExperienciaCandidato> task)
        {
            var viewModelList = new List<ExperienciaCandidatoViewModel>();

            foreach (var item in task)
            {
                viewModelList.Add(Mapear(item));
            }
            IEnumerable<ExperienciaCandidatoViewModel> viewModelListIEnum = viewModelList;

            return viewModelListIEnum;
        }
    }
}
