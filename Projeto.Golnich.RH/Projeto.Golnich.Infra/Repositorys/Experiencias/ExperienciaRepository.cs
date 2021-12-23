using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Projeto.Golnich.AppService;
using Projeto.Golnich.Domain.Experiencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Golnich.Infra.Repositorys
{
    public class ExperienciaRepository : IExperienciasRepository
    {
        private readonly Genericos _Gen;

        public ExperienciaRepository(Genericos Gen)
        {
            _Gen = Gen;
        }

        public void Cadastrar(Experiencias entidade)
        {

            using (var db = _Gen.BuscaConexao())
            {
                db.Experiencias.Add(entidade);
                db.SaveChanges();
            }

        }

        public IReadOnlyList<Experiencias> Listar()
        {
            using (var db = _Gen.BuscaConexao())
            {
                return db.Experiencias.ToList();
            }
        }

        public void Atualizar(Experiencias entidade)
        {

            using (var db = _Gen.BuscaConexao())
            {
                db.Entry(entidade).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public void Deletar(int Id)
        {

            using (var db = _Gen.BuscaConexao())
            {
                var entidade = db.Experiencias.FirstOrDefault(l => l.IdExperiencia == Id);
                db.Remove(entidade);
                db.SaveChanges();
            }

        }
    }
}
