using System;

namespace Candidatos.Domain.Entities
{
    public sealed class CandidateExperience: EntityBase
    {
        public int IdCandidateExperience { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int IdCandidate { get; set; }
        public Candidate Candidate { get; set; }
    }
}
