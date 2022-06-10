using System;
using System.Collections.Generic;
using Candidatos.Domain.Entities._Base;
using Candidatos.Domain.Entities._CandidateExperience;

namespace Candidatos.Domain.Entities._Candidate
{
    public class Candidate : EntityBase
    {
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }

        // relationship
        public virtual ICollection<CandidateExperience> CandidateExperiences { get; set; }
    }
}
