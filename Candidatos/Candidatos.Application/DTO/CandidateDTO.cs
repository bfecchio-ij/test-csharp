using System;
using System.ComponentModel.DataAnnotations;

namespace Candidatos.Application.DTO
{
    public class CandidateDTO
    {
        [Key]
        public int IdCandidate { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Email { get; set; }
    }
}
