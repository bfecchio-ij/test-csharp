using Candidatos.Domain.Interfaces.Repositories;
using Candidatos.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidatos.Domain.Services
{
    public class ServiceBase<entity> : IServiceBase<entity> where entity : class
    {
        private readonly IRepositoryBase<entity> _repository;

        public ServiceBase(IRepositoryBase<entity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<entity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<entity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(entity obj)
        {
            await _repository.RemoveAsync(obj);
        }

        public async Task UpdateAsync(entity obj)
        {
            await _repository.UpdateAsync(obj);
        }

        async Task IServiceBase<entity>.AddAsync(entity obj)
        {
            await _repository.AddAsync(obj);
        }
    }
}
