using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ExperienciasCandidatosRepository
    {
        public async Task<IEnumerable<ExperienciaCandidato>> GetExperienciasCandidatos(CandidatoDbContext _context)
        {
            return (await _context.ExperienciasCandidatos.ToListAsync());
        }

        public async Task<ExperienciaCandidato> GetExperienciaCandidato(CandidatoDbContext _context, int idExperienciaCandidato)
        {

            return (await _context.ExperienciasCandidatos.FindAsync(idExperienciaCandidato));
        }

        public async Task<string> SalvarCandidato(CandidatoDbContext _context, ExperienciaCandidato experienciaCandidato)
        {
            var edit = _context.ExperienciasCandidatos.Any(e => e.IdExperienciaCandidato == experienciaCandidato.IdExperienciaCandidato);
            if (!edit)
            {
                try
                {
                    _context.ExperienciasCandidatos.Add(experienciaCandidato);
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
                    _context.ExperienciasCandidatos.Update(experienciaCandidato);
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
                var experienciaCandidato = await _context.ExperienciasCandidatos.FindAsync(id);
                _context.ExperienciasCandidatos.Remove(experienciaCandidato);
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
