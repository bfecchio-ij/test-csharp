using CQRS.INFO.Models.Data;
using CQRS.INFO.Models.Entities;
using CQRS.INFO.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.INFO.Services
{
    public class CandidatesExperienceServices : ICandidatesExperienceServices
    {
        private readonly ApplicationContext _context;
        public CandidatesExperienceServices(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CandidateExperience>> GetListOfExperiences()
        {
            return await _context.CandidatesExperiences
           .ToListAsync();
        }
        public async Task<CandidateExperience> GetExperienceById(int id)
        {
            return await _context.CandidatesExperiences
           .FirstOrDefaultAsync(x => x.Id == id);
        }
       
        public async Task<CandidateExperience> CreateExperience(CandidateExperience experience)
        {
            _context.CandidatesExperiences.Add(experience);
            await _context.SaveChangesAsync();
            return experience;
        }

        public async Task<int> DeleteExperience(CandidateExperience experience)
        {
            _context.CandidatesExperiences.Remove(experience);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateExperience(CandidateExperience experience)
        {
            _context.CandidatesExperiences.Update(experience);
            return await _context.SaveChangesAsync();
        }
    }
}
