using System;
using Candidatos.Domain.Entities._Base;
using Candidatos.Domain.Entities._Candidate;

namespace Candidatos.Domain.Entities._CandidateExperience
{
    public class CandidateExperience : EntityBase
    {
        public int IdCandidateExperience { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        // relationship
        public int IdCandidate { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}
