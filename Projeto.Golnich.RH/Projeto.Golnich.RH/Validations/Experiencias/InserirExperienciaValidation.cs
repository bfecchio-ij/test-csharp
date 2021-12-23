using FluentValidation;
using Projeto.Golnich.RH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Golnich.RH.Validations.Experiencias
{
    public class InserirExperienciaValidation : AbstractValidator<ExperienciaViewModel>
    {

        public InserirExperienciaValidation()
        {
            var atual = false;

            RuleFor(l => l.Empresa)
               .NotEmpty().WithMessage("O campo Empresa precisa ser preenchido");

            RuleFor(l => l.Cargo)
                .NotEmpty().WithMessage("O campo Cargo precisa ser preenchido");

            RuleFor(l => l.Descricao)
                .NotEmpty().WithMessage("O campo Descricao precisa ser preenchido");

            RuleFor(l => l.DS_Salario)
             .NotEmpty().WithMessage("O campo Salario precisa ser preenchido");

            RuleFor(l => l.DataInicio)
          .NotEmpty().WithMessage("O campo data de inicio precisa ser preenchido");

            RuleFor(l => l.Atual).Custom((x, context) =>
            {
                if (x)
                {
                    atual = true;
                }
            });

            if (atual)
            {
                RuleFor(l => l.DataFinal)
                .NotEmpty().WithMessage("O campo data de saida precisa ser preenchido");
            }

            RuleFor(l => l.IdCandidato).Custom((x, context) =>
            {
                if (x == 0)
                {
                    context.AddFailure(context.PropertyName, "Um candidato precisa ser selecionado");
                }
            });
        }
    }
}
