using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Projeto.Golnich.AppService;
using Projeto.Golnich.Domain.Experiencias;
using Projeto.Golnich.RH.Models;
using Projeto.Golnich.RH.Validations.Experiencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Golnich.RH.Controllers
{
    public class ExperienciasController : Controller
    {
        private readonly ILogger<ExperienciasController> _logger;
        private readonly ICandidatosRepository _repoCandidato;
        private readonly IExperienciasRepository _repoExperiencia;

        public ExperienciasController(ILogger<ExperienciasController> logger, ICandidatosRepository repoCandidato, IExperienciasRepository repoExperiencia)
        {
            _logger = logger;
            _repoCandidato = repoCandidato;
            _repoExperiencia = repoExperiencia;
        }
        #region Telas
        public IActionResult DadosExperiencias()
        {
            return View();
        }

        public IActionResult CadastroExperiencias()
        {
            var lstCandidatos = _repoCandidato.Listar()
                 .Select(l => new SelectListItem() { Text = l.Nome.ToString() + " " + l.Sobrenome.ToString(), Value = l.IdCandidato.ToString() }).ToList();
            ViewBag.Candidatos = lstCandidatos;

            return View();
        }

        public IActionResult AlterarExperiencia(int idExperiencia)
        {
            var experiencia = _repoExperiencia.Listar().FirstOrDefault(l => l.IdExperiencia == idExperiencia);
            var dataSaidaConvertida = new DateTime();
            var retornoTela = new ExperienciaViewModel();
            if (experiencia.DataSaida != null)
            {
                dataSaidaConvertida = Convert.ToDateTime(experiencia.DataSaida);
                retornoTela.Atual = false;
            }
            else
            {
                retornoTela.Atual = true;
            }
            retornoTela.IdExperiencia = experiencia.IdExperiencia;
            retornoTela.IdCandidato = experiencia.IdCandidato;
            retornoTela.Empresa = experiencia.Empresa;
            retornoTela.Cargo = experiencia.Cargo;
            retornoTela.Descricao = experiencia.Descricao;
            retornoTela.DS_Salario = experiencia.Salario.ToString().Replace(",", ".");
            retornoTela.DS_DataInicio = experiencia.DataInicio.Date.ToString("yyyy-MM-dd");
            retornoTela.DS_DataFinal = experiencia == null ? "" : dataSaidaConvertida.Date.ToString("yyyy-MM-dd");

            var lstCandidatos = _repoCandidato.Listar()
               .Select(l => new SelectListItem() { Text = l.Nome.ToString() + " " + l.Sobrenome.ToString(), Value = l.IdCandidato.ToString() }).ToList();
            ViewBag.Candidatos = lstCandidatos;
            return View(retornoTela);
        }
        #endregion

        #region Metodos 
        public JsonResult InserirExperiencia(ExperienciaViewModel dadosTela)
        {
            var validacao = new InserirExperienciaValidation().Validate(dadosTela);
            if (validacao.IsValid)
            {
                var novaEntidade = new Experiencias();
                novaEntidade.IdCandidato = dadosTela.IdCandidato;
                novaEntidade.Empresa = dadosTela.Empresa;
                novaEntidade.Cargo = dadosTela.Cargo;
                novaEntidade.Descricao = dadosTela.Descricao;
                novaEntidade.Salario = decimal.Parse(dadosTela.DS_Salario);
                novaEntidade.DataInicio = dadosTela.DataInicio;
                novaEntidade.DataSaida = dadosTela.Atual ? null : dadosTela.DataFinal;
                novaEntidade.DataCad = DateTime.Now;
                novaEntidade.DataAtu = DateTime.Now;

                _repoExperiencia.Cadastrar(novaEntidade);

                dadosTela.MensagemCallback = "Experiencia cadastrada com sucesso";
            }
            else
            {
                dadosTela.MensagemCallback = validacao.Errors[0].ErrorMessage;
                dadosTela.Erros = validacao.Errors;
            }

            dadosTela.IsSucess = validacao.IsValid;


            return Json(dadosTela);
        }

        public JsonResult AtualizarExperiencia(ExperienciaViewModel dadosTela)
        {

            var validacao = new InserirExperienciaValidation().Validate(dadosTela);
            if (validacao.IsValid)
            {
                var Entidade = _repoExperiencia.Listar().FirstOrDefault(l => l.IdExperiencia == dadosTela.IdExperiencia);
                Entidade.Empresa = dadosTela.Empresa;
                Entidade.Cargo = dadosTela.Cargo;
                Entidade.Descricao = dadosTela.Descricao;
                Entidade.Salario = decimal.Parse(dadosTela.DS_Salario);
                Entidade.DataInicio = dadosTela.DataInicio;
                Entidade.DataSaida = dadosTela.Atual ? null : dadosTela.DataFinal;
                Entidade.DataAtu = DateTime.Now;

                _repoExperiencia.Atualizar(Entidade);

                dadosTela.MensagemCallback = "Experiencia cadastrada com sucesso";
            }
            else
            {
                dadosTela.MensagemCallback = validacao.Errors[0].ErrorMessage;
                dadosTela.Erros = validacao.Errors;
            }
            dadosTela.IsSucess = validacao.IsValid;

            return Json(dadosTela);
        }

        public ActionResult PesquisarExperiencia(ExperienciaViewModel filtros)
        {
            var lstExperiencias = _repoExperiencia.Listar().ToList();
            var lstCandidatos = _repoCandidato.Listar().ToList();

            lstExperiencias.ForEach(l =>
            {
                var candidato = lstCandidatos.FirstOrDefault(x => x.IdCandidato == l.IdCandidato);
                l.Nome_Candidato = candidato.Nome + " " + candidato.Sobrenome;
            });

            if (!string.IsNullOrWhiteSpace(filtros.Empresa))
            {
                lstExperiencias = lstExperiencias.Where(l => l.Empresa.Contains(filtros.Empresa)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(filtros.Cargo))
            {
                lstExperiencias = lstExperiencias.Where(l => l.Empresa.Contains(filtros.Cargo)).ToList();

            }
            if (!string.IsNullOrWhiteSpace(filtros.DS_MinSalario))
            {
                lstExperiencias = lstExperiencias.Where(l => l.Salario >= decimal.Parse(filtros.DS_MinSalario)).ToList();

            }
            if (!string.IsNullOrWhiteSpace(filtros.DS_MaxSalario))
            {
                lstExperiencias = lstExperiencias.Where(l => l.Salario <= decimal.Parse(filtros.DS_MaxSalario)).ToList();
            }


            return PartialView("_PartialResultExperiencias", lstExperiencias);
        }


        public ActionResult DeletarExperiencia(int idExperiencia)
        {
            _repoExperiencia.Deletar(idExperiencia);
            var lstAtualizada = _repoExperiencia.Listar().ToList();
            var lstCandidatos = _repoCandidato.Listar().ToList();

            lstAtualizada.ForEach(l =>
            {
                var candidato = lstCandidatos.FirstOrDefault(x => x.IdCandidato == l.IdCandidato);
                l.Nome_Candidato = candidato.Nome + " " + candidato.Sobrenome;


            });

            return PartialView("_PartialResultExperiencias", lstAtualizada);
        }

        #endregion

    }
}
