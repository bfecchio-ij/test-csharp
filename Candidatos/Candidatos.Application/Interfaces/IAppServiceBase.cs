using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidatos.Application.Interfaces
{
    public interface IAppServiceBase<entity> where entity : class
    {
        Task<IEnumerable<entity>> GetAllAsync();
        Task<entity> GetByIdAsync(int id);
        Task UpdateAsync(entity obj);
        Task RemoveAsync(entity obj);
        Task AddAsync(entity obj);
    }
}
