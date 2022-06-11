using Candidatos.Application.Interfaces;
using Candidatos.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Candidatos.Application.Implementations
{
    public class AppServiceBase<entity> : IAppServiceBase<entity> where entity : class
    {
        private readonly IServiceBase<entity> _serviceBase;

        public AppServiceBase(IServiceBase<entity> service)
        {
            _serviceBase = service;
        }

        public void Add(entity obj)
        {
            _serviceBase.Add(obj);
        }

        public IEnumerable<entity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public entity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public void Remove(entity obj)
        {
            _serviceBase.Remove(obj);
        }

        public void Update(entity obj)
        {
            _serviceBase.Update(obj);
        }
    }
}
