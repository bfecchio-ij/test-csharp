namespace test_CSharp.Models
{
    public class CandidateExperience
    {
        public int IdCandidate { get; set; }
        public Candidate Candidate { get; set; }
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
