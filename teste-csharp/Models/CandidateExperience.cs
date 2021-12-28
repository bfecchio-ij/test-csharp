using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teste_csharp.Models
{
    public class CandidateExperience
    {
        [Key]
        public int IdCandidateExperience { get; set; }
        public int IdCandidate { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public Double Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
