namespace test_CSharp.Models
{
    public class Candidate
    {
        public int IdCandidate { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }

    }
}
