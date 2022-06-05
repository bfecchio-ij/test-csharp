using System.ComponentModel.DataAnnotations;

namespace test_CSharp.Models.DTO
{
    public class CandidateExperienceDTO
    {
        public int IdCandidate { get; set; }
        public int IdCandidateExperience { get; set; }
        public string Company { get; set; } = string.Empty;
        public string Job { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
