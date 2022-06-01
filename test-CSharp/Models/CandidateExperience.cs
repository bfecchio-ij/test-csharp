using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_CSharp.Models
{
    public class CandidateExperience
    {
        [Key]
        public int IdCandidateExperience { get; set; }

        public int IdCandidate { get; set; }
        [ForeignKey("IdCandidate")]
        public Candidate Candidate { get; set; } = new();

        [Required]
        [MaxLength(100)]
        public string Company { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Job { get; set; } = string.Empty;

        [Required]
        [MaxLength(4000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Salary { get; set; }
        [Required]

        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]

        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
