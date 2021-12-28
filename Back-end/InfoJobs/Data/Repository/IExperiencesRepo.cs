using InfoJobs.Models;
using System.Threading.Tasks;

namespace InfoJobs.Data.Repository
{
    public interface IExperiencesRepo
    {


        //GENERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();



        //CANDIDATES EXPERIENCES
        Task<CandidateExperiences[]> GetAllExperiencesAsync();
        Task<CandidateExperiences> GetExperiencesAsyncById(int id);

        Task<CandidateExperiences[]> GetExperiencesAsyncByCandidatesId(int idCandidates);


    }
}
