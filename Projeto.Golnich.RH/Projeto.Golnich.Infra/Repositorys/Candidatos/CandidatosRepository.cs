using Microsoft.Extensions.Configuration;
using Projeto.Golnich.AppService;
using Projeto.Golnich.Domain.Candidatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Golnich.Infra.Repositorys
{
    public class CandidatosRepository : ICandidatosRepository
    {
        private readonly Genericos _Gen;
        public CandidatosRepository(Genericos Gen)
        {
            _Gen = Gen;
        }

        public void Cadastrar(Candidatos entidade)
        {

            using (var db = _Gen.BuscaConexao())
            {
                db.Candidatos.Add(entidade);
                db.SaveChanges();
            }

        }

        public IReadOnlyList<Candidatos> Listar()
        {
            using (var db = _Gen.BuscaConexao())
            {
                return db.Candidatos.ToList();
            }
        }

        public void Atualizar(Candidatos entidade)
        {

            using (var db = _Gen.BuscaConexao())
            {
                db.Entry(entidade).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

        }
        public void Deletar(int Id)
        {

            using (var db = _Gen.BuscaConexao())
            {
                var entidade = db.Candidatos.FirstOrDefault(l => l.IdCandidato == Id);
                var experienciasVinculadas = db.Experiencias.Where(l => l.IdCandidato == Id).ToList();
                if (experienciasVinculadas != null)
                {
                    if (experienciasVinculadas.Count() > 0)
                    {
                        foreach(var experiencia in experienciasVinculadas)
                        {
                            db.Remove(experiencia);
                            db.SaveChanges();
                        }
                    }
                }
                db.Remove(entidade);
                db.SaveChanges();

            }


        }
    }
}
