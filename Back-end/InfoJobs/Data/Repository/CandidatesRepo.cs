using InfoJobs.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace InfoJobs.Data.Repository
{
    public class CandidatesRepo : ICandidatesRepo
    {
        private readonly DataContext _context;

        public CandidatesRepo(DataContext context)
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


        public async Task<Candidates[]> GetAllCandidatesAsync()
        {
            IQueryable<Candidates> query = _context.Candidates;

          

            query = query.AsNoTracking()
                         .OrderBy(candidates => candidates.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Candidates> GetCandidatesAsyncById(int idCandidate)
        {
            IQueryable<Candidates> query = _context.Candidates;

            query = query.AsNoTracking()
                .OrderBy(candidates => candidates.Id)
                .Where(candidates => candidates.Id == idCandidate);


            return await query.FirstOrDefaultAsync();
        }

        public async Task<CandidateExperiences[]> GetAllExperiencesAsync()
        {

            IQueryable<CandidateExperiences> query = _context.CandidateExperiences;

            query = query.AsNoTracking()
                .OrderBy(experiences => experiences.Id);


                return await query.ToArrayAsync();


        }
    }
}
