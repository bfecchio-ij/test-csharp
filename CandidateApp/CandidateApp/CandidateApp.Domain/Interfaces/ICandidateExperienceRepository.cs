using CandidateApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateApp.Domain.Interfaces
{
    public interface ICandidateExperienceRepository : IRepository<CandidateExperience>
    {
        CandidateExperience Get(Guid id);

        IEnumerable<CandidateExperience> GetAll();
    }
}
