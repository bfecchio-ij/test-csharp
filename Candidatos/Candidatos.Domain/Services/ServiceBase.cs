using Candidatos.Domain.Interfaces.Repositories;
using Candidatos.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Candidatos.Domain.Services
{
    public class ServiceBase<entity> : IServiceBase<entity> where entity : class
    {
        private readonly IRepositoryBase<entity> _repository;

        public ServiceBase(IRepositoryBase<entity> repository)
        {
            _repository = repository;
        }

        public void Add(entity obj)
        {
            _repository.Add(obj);
        }

        public IEnumerable<entity> GetAll()
        {
            return _repository.GetAll();
        }

        public entity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(entity obj)
        {
            _repository.Remove(obj);
        }

        public void Update(entity obj)
        {
            _repository.Update(obj);
        }
    }
}
