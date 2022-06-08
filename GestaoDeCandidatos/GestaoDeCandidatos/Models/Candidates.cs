using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoDeCandidatos.Models
{   
    [Table("candidates")]
    public class Candidates
    {
        

        public Candidates(int idCandidate, string name,string surname, DateTime birthdate, string email, DateTime insertDate, DateTime? modifyDate)
        {
            IdCandidate = idCandidate;
            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            Email = email;
            InsertDate = insertDate;
            ModifyDate = modifyDate;
        }

        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }

    }
}
