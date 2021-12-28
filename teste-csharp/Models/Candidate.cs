using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace teste_csharp.Models
{
       
    public class Candidate
    {
        [Key]
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }

        List<CandidateExperience> candidateExperiences = new List<CandidateExperience>();
        

    }
}
