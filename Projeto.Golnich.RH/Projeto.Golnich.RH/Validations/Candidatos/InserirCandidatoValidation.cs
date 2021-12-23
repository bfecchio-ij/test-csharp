using FluentValidation;
using Projeto.Golnich.AppService;
using Projeto.Golnich.RH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Golnich.RH.Validations
{
    public class InserirCandidatoValidation : AbstractValidator<CandidatoViewModel>
    {
        private readonly ICandidatosRepository _repoCandidatos;

        public InserirCandidatoValidation(ICandidatosRepository repoCandidatos)
        {
            _repoCandidatos = repoCandidatos;

            RuleFor(l => l.Nome)
                .NotEmpty().WithMessage("O campo nome precisa ser preenchido");

            RuleFor(l => l.Email)
                .NotEmpty().WithMessage("O campo email precisa ser preenchido");

            RuleFor(l => l.DataNascimento)
                .NotEmpty().WithMessage("O campo Data de Nascimento precisa ser preenchido");

            RuleFor(l => l.Nome).Custom((l, context) =>
            {
                if (!string.IsNullOrWhiteSpace(l))
                {
                    if (!l.Contains(" "))
                    {
                        context.AddFailure(context.PropertyName, "Necessario conter um sobrenome");
                    }
                }    
            });
            RuleFor(l => l.Email).Custom((l, context) =>
            {
                if (!string.IsNullOrWhiteSpace(l))
                {
                    var isExiste = _repoCandidatos.Listar().FirstOrDefault(x => x.Email == l);
                    if (isExiste != null)
                    {
                        context.AddFailure(context.PropertyName, "Email ja cadastrado no sistema");

                    }

                }
            });
        }
    }
}
