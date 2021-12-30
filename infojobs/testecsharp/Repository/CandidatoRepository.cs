using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class CandidatoRepository
    {
        public async Task<IEnumerable<Candidato>> GetCandidatos(CandidatoDbContext _context)
        {
            return (await _context.Candidato.ToListAsync());
        }

        public async Task<Candidato> GetCandidato(CandidatoDbContext _context, int idCandidato)
        {

            return (await _context.Candidato.FindAsync(idCandidato));
        }

        public async Task<string> SalvarCandidato(CandidatoDbContext _context, Candidato candidato)
        {
            var edit = _context.Candidato.Any(e => e.IdCandidato == candidato.IdCandidato);
            if(!edit)
            {
                try
                {
                    _context.Candidato.Add(candidato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    return e.ToString();
                }
            }
            else
            {
                try
                {
                    _context.Candidato.Update(candidato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    return e.ToString();
                }
            }
            return null;
        }

        public async Task<string> DeletarExperiencia(CandidatoDbContext _context, int id)
        {
            try
            {
                var candidato = await _context.Candidato.FindAsync(id);
                _context.Candidato.Remove(candidato);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                return e.ToString();
            }
            return null;
        }
    }
}
