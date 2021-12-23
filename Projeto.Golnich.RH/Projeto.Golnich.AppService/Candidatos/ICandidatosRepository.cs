using Projeto.Golnich.Domain.Candidatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Golnich.AppService
{
   public interface ICandidatosRepository
    {
        void Cadastrar(Candidatos entidade);
        void Atualizar(Candidatos entidade);
        void Deletar(int id);
        IReadOnlyList<Candidatos> Listar();
    }
}
