using InfoJobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace InfoJobs.Data.Repository
{
    public class ExperiencesRepo : IExperiencesRepo
    {
        private readonly DataContext _context;

        public ExperiencesRepo(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);

        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }



        public async Task<CandidateExperiences[]> GetAllExperiencesAsync()
        {
            IQueryable<CandidateExperiences> query = _context.CandidateExperiences;

            query = query.AsNoTracking()
                .OrderBy(experience => experience.Id);

            return await query.ToArrayAsync();


        }

        public async Task<CandidateExperiences> GetExperiencesAsyncById(int id)
        {

            IQueryable<CandidateExperiences> query = _context.CandidateExperiences;

            query = query.AsNoTracking()
                .OrderBy(experience => experience.Id)
                .Where(experience => experience.Id == id);

            return await query.FirstOrDefaultAsync();

        }

        public async Task<CandidateExperiences[]> GetExperiencesAsyncByCandidatesId(int idCandidate)
        {

            IQueryable<CandidateExperiences> query = _context.CandidateExperiences;

            query = query.AsNoTracking()
                .OrderBy(experience => experience.Id)
                .Where(experience => experience.CandidatesId == idCandidate);

            return await query.ToArrayAsync();




        }
    }
}
