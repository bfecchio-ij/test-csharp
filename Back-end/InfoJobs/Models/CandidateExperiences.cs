using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoJobs.Models
{
    [Table("CandidateExperiences")]
    public class CandidateExperiences
    {


        [Key()]
        public int Id { get; set; }

        public string Company { get; set; }

        

        public string Job { get; set; }

        public string Description { get; set; }

        public float Salary { get; set; }

       public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; } = null;

        public DateTime InsertDate { get; set; } = DateTime.UtcNow;

        public DateTime? ModifyDate { get; set; } = null;

       

        [ForeignKey("Candidates")]
        public  int CandidatesId { get; set; }
        public virtual Candidates Candidates { get; set; }
        public CandidateExperiences(int id, string company, string job, int candidatesId)
        {
            this.Id = id;
            this.Company = company;
            this.Job = job;
            this.CandidatesId = candidatesId;
           
        
           
        }

        public CandidateExperiences()
        {
        }
    }
}
