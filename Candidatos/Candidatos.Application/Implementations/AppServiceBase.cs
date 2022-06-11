using Candidatos.Application.Interfaces;
using Candidatos.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidatos.Application.Implementations
{
    public class AppServiceBase<entity> : IAppServiceBase<entity> where entity : class
    {
        private readonly IServiceBase<entity> _serviceBase;

        public AppServiceBase(IServiceBase<entity> service)
        {
            _serviceBase = service;
        }

        public async Task AddAsync(entity obj)
        {
            await _serviceBase.AddAsync(obj);
        }

        public async Task<IEnumerable<entity>> GetAllAsync()
        {
            return await _serviceBase.GetAllAsync();
        }

        public async Task<entity> GetByIdAsync(int id)
        {
            return await _serviceBase.GetByIdAsync(id);
        }

        public async Task RemoveAsync(entity obj)
        {
            await _serviceBase.RemoveAsync(obj);
        }

        public async Task UpdateAsync(entity obj)
        {
            await _serviceBase.UpdateAsync(obj);
        }
    }
}
