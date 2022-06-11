using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidatos.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<entity> where entity : class
    {
        Task<IEnumerable<entity>> GetAllAsync();
        Task<entity> GetByIdAsync(int id);
        Task AddAsync(entity obj);
        Task UpdateAsync(entity obj);
        Task RemoveAsync(entity obj);
    }
}
