using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces;
using Candidatos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidatos.Infra.Data.Repositories
{
    public class CandidateExperienceRepository : ICandidateExperienceRepository
    {
        private readonly JobContext _context;

        public CandidateExperienceRepository(JobContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CandidateExperience>> GetCandidateExperiencesAsync()
        {
            var candidateExperience = await _context.CandidateExperiences.AsNoTracking().ToListAsync();
            if (candidateExperience == null || candidateExperience.Count == 0) return null;

            return candidateExperience;
        }

        public async Task<CandidateExperience> GetByIdAsync(int? id)
        {
            var candidateExperience = await _context.CandidateExperiences.AsNoTracking().Where(x => x.IdCandidateExperience == id.Value).FirstOrDefaultAsync();
            if (candidateExperience == null) return null;
            
            candidateExperience.Candidate = await _context.Candidates.AsNoTracking().FirstOrDefaultAsync(x => x.IdCandidate == candidateExperience.IdCandidate);
            return candidateExperience;
        }
        
        public async Task<CandidateExperience> CreateAsync(CandidateExperience candidateExperience)
        {
            _context.ChangeTracker.Clear();
            _context.Add(candidateExperience);
            await _context.SaveChangesAsync();
            return candidateExperience;
        }

        public async Task<CandidateExperience> UpdateAsync(CandidateExperience candidateExperience)
        {
            _context.ChangeTracker.Clear();
            candidateExperience.ModifyDate = DateTime.Now;
            _context.Update(candidateExperience);
            await _context.SaveChangesAsync();
            return candidateExperience;
        }
        
        public async Task<CandidateExperience> RemoveAsync(CandidateExperience candidateExperience)
        {
            _context.ChangeTracker.Clear();
            _context.Remove(candidateExperience);
            await _context.SaveChangesAsync();
            return candidateExperience;
        }

    }
}
