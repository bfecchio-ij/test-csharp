using System.Collections.Generic;

namespace Candidatos.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<entity> where entity : class
    {
        IEnumerable<entity> GetAll();
        entity GetById(int id);
        void Add(entity obj);
        void Update(entity obj);
        void Remove(entity obj);
    }
}
