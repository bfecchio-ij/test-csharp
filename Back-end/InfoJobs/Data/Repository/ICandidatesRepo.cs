using InfoJobs.Models;
using System.Threading.Tasks;

namespace InfoJobs.Data.Repository
{
    public interface ICandidatesRepo
    {

        //GENERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();


        //CANDIDATES
        Task<Candidates[]> GetAllCandidatesAsync();
        Task<Candidates> GetCandidatesAsyncById(int idCandidate);
        

        



    }
}
