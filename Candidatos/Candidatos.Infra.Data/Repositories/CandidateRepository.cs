using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces;
using Candidatos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidatos.Infra.Data.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        JobContext _context = new JobContext();

        public async Task<IEnumerable<Candidate>> GetCandidatesAsync()
        {
            var candidate = await _context.Candidates.AsNoTracking().ToListAsync();
            if (candidate == null || candidate.Count == 0) return null;
            
            return candidate;
        }
        
        public async Task<Candidate> GetByIdAsync(int? id)
        {
            var candidate = await _context.Candidates.AsNoTracking().FirstOrDefaultAsync(c => c.IdCandidate == id);
            if (candidate == null) return null;
            
            return candidate;
        }
        
        public async Task<Candidate> GetByIdWithExperiencesAsync(int? id)
        {
            var candidate = await _context.Candidates.AsNoTracking().Include(x => x.CandidateExperiences).FirstOrDefaultAsync(c => c.IdCandidate == id);
            if (candidate == null) return null;

            return candidate;
        }

        public async Task<bool> GetByEmail(string email)
        {
            var candidate = await _context.Candidates.AsNoTracking().Include(x => x.CandidateExperiences).FirstOrDefaultAsync(c => c.Email == email);
            if (candidate.Email == null) return false;

            return true;
        }

        public async Task<Candidate> CreateAsync(Candidate candidate)
        {
            _context.ChangeTracker.Clear();
            _context.Add(candidate);
            await _context.SaveChangesAsync();
            return candidate;
        }

        public async Task<Candidate> UpdateAsync(Candidate candidate)
        {
            _context.ChangeTracker.Clear();
            _context.Entry(candidate).Property(c => c.ModifyDate).CurrentValue = DateTime.Now;
            _context.Update(candidate);
            await _context.SaveChangesAsync();
            return candidate;
        }
        
        public async Task<Candidate> RemoveAsync(Candidate candidate)
        {
            _context.ChangeTracker.Clear();
            _context.Remove(candidate);
            await _context.SaveChangesAsync();
            return candidate;
        }

        
    }
}
