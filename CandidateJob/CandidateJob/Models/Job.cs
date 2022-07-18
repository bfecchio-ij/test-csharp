using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateJob.Models
{
    public class Job
    {
        [Key]
        public int IdCandidateExperience { get; set; }
        [ForeignKey("Candidate")]
        public int IdCandidate { get; set; }
        public virtual Candidate Candidate { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Company { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Jobs { get; set; }
        [Column(TypeName = "varchar(4000)")]
        public string Description { get; set; }
        [Column(TypeName = "numeric(8,2)")]
        public decimal Salary { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BaginDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime InsertDate { get; set; } = DateTime.UtcNow;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? ModifyDate { get; set; } = DateTime.UtcNow;
    }
}
