using Projeto.Golnich.Domain.Experiencias;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Golnich.AppService
{
   public interface IExperienciasRepository
    {
        void Cadastrar(Experiencias entidade);
        void Atualizar(Experiencias entidade);
        void Deletar(int id);
        IReadOnlyList<Experiencias> Listar();
    }
}
