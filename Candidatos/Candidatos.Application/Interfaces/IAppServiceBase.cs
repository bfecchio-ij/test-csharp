using System.Collections.Generic;

namespace Candidatos.Application.Interfaces
{
    public interface IAppServiceBase<entity> where entity : class
    {
        void Add(entity obj);
        void Update(entity obj);
        void Remove(entity obj);
        IEnumerable<entity> GetAll();
        entity GetById(int id);
    }
}
