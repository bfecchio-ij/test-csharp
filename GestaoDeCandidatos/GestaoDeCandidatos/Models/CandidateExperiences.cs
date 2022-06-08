using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoDeCandidatos.Models
{
    [Table("candidateexperiences")]
    public class CandidateExperiences
    {

        public CandidateExperiences(int idCandidateExperience, int idCandidate, string company, string job, string description, decimal salary, DateTime beginDate,DateTime? endDate, DateTime insertDate, DateTime? modifyDate)
        {
            IdCandidateExperience = idCandidateExperience;
            IdCandidate = idCandidate;
            Company = company;
            Job = job;
            Description = description;
            Salary = salary;
            BeginDate = beginDate;
            EndDate = endDate;
            InsertDate = insertDate;
            ModifyDate = modifyDate;
        }

        public int IdCandidateExperience { get; set; }
        public int IdCandidate { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public Candidates Experiences { get; set; }
    }
}
