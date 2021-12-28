using InfoJobs.Models;
using System;

namespace InfoJobs.Dtos
{
    public class CandidateExperiencesDto
    {

        public int Id { get; set; }

        public string Company { get; set; }



        public string Job { get; set; }

        public string Description { get; set; }

        public float Salary { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; } 

        public DateTime InsertDate { get; set; } 

        public DateTime? ModifyDate { get; set; } 
      

        public int CandidatesId { get; set; }

    }
}
