using System;
using System.Collections.Generic;

namespace Candidatos.Domain.Entities
{
    public sealed class Candidate: EntityBase
    {
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public ICollection<CandidateExperience> CandidateExperiences { get; set; }
    }
}
