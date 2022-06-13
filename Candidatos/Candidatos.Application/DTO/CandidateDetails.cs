using Candidatos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidatos.Application.DTO
{
    public class CandidateDetails
    {
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }

        public IEnumerable<CandidateExperience> Experiences { get; set; }
    }
}
