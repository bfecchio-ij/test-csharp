using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto.Golnich.AppService;
using Projeto.Golnich.Domain.Candidatos;
using Projeto.Golnich.RH.Models;
using Projeto.Golnich.RH.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Golnich.RH.Controllers
{
    public class CandidatosController : Controller
    {
        private readonly ILogger<CandidatosController> _logger;
        private readonly ICandidatosRepository _repoCandidato;
        private readonly IExperienciasRepository _repoExperiencia;

        public CandidatosController(ILogger<CandidatosController> logger, ICandidatosRepository repoCandidato, IExperienciasRepository repoExperiencia)
        {
            _logger = logger;
            _repoCandidato = repoCandidato;
            _repoExperiencia = repoExperiencia;
        }

        #region Telas
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CadastroCandidatos()
        {
            return View();
        }
        public IActionResult DadosCandidatos()
        {
            return View();
        }

        public IActionResult AtualizarCandidatos(int idCandidato)
        {
            var entidadeBanco = _repoCandidato.Listar().FirstOrDefault(l => l.IdCandidato == idCandidato);
            var retornoTela = new CandidatoViewModel();
            retornoTela.Id = entidadeBanco.IdCandidato;
            retornoTela.Nome = entidadeBanco.Nome + " " + entidadeBanco.Sobrenome;
            retornoTela.DataNascimento = entidadeBanco.DataNascimento;
            retornoTela.Email = entidadeBanco.Email;
            retornoTela.Ds_Data = entidadeBanco.DataNascimento.Date.ToString("yyyy-MM-dd");
            return View(retornoTela);
        }
        #endregion

        #region Metodos
        public ActionResult PesquisarCandidatos(CandidatoViewModel filtrosTela)
        {
            var lstCandidatos = _repoCandidato.Listar().ToList();

            if (!string.IsNullOrWhiteSpace(filtrosTela.Nome))
            {
                lstCandidatos = lstCandidatos.Where(l => l.Nome.Contains(filtrosTela.Nome) || l.Sobrenome.Contains(filtrosTela.Nome)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(filtrosTela.Email))
            {
                lstCandidatos = lstCandidatos.Where(l => l.Nome.Contains(filtrosTela.Email)).ToList();
            }

            return PartialView("_PartialResultCandidatos", lstCandidatos);
        }

        public JsonResult InserirCandidato(CandidatoViewModel dadosTela)
        {
            var validacoes = new InserirCandidatoValidation(_repoCandidato).Validate(dadosTela);
            if (validacoes.IsValid)
            {
                var novaEntidade = new Candidatos();
                novaEntidade.Nome = dadosTela.Nome.Split(" ")[0];
                novaEntidade.Sobrenome = dadosTela.Nome.Split(" ")[1];
                novaEntidade.Email = dadosTela.Email;
                novaEntidade.DataNascimento = dadosTela.DataNascimento;
                novaEntidade.DataCad = DateTime.Now;
                novaEntidade.DataAtu = DateTime.Now;

                _repoCandidato.Cadastrar(novaEntidade);

                dadosTela.MensagemCallBack = "Candidato cadastrado com sucesso";
            }
            else
            {
                dadosTela.MensagemCallBack = validacoes.Errors[0].ErrorMessage;
                dadosTela.Erros = validacoes.Errors;

            }

            dadosTela.IsSucess = validacoes.IsValid;

            return Json(dadosTela);
        }

        public JsonResult AtualizarCandidato(CandidatoViewModel dadosTela)
        {
            var validacoes = new EditarCandidatoValidation(_repoCandidato).Validate(dadosTela);
            if (validacoes.IsValid)
            {
                var entidadeBanco = _repoCandidato.Listar().FirstOrDefault(l => l.IdCandidato == dadosTela.Id);
                entidadeBanco.Nome = dadosTela.Nome.Split(" ")[0];
                entidadeBanco.Sobrenome = dadosTela.Nome.Split(" ")[1];
                entidadeBanco.DataNascimento = dadosTela.DataNascimento;
                entidadeBanco.DataAtu = DateTime.Now;
                _repoCandidato.Atualizar(entidadeBanco);

                dadosTela.MensagemCallBack = "Candidato editado com sucesso";
            }
            else
            {
                dadosTela.MensagemCallBack = validacoes.Errors[0].ErrorMessage;
                dadosTela.Erros = validacoes.Errors;
            }
            dadosTela.IsSucess = validacoes.IsValid;

            return Json(dadosTela);
        }

        public ActionResult DeletarCandidato(int IdCandidato)
        {
            _repoCandidato.Deletar(IdCandidato);
            var lstAtualizada = _repoCandidato.Listar().ToList();

            return PartialView("_PartialResultCandidatos", lstAtualizada);
        }
        #endregion

    }
}
