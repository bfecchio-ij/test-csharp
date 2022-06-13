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
        [DataType(DataType.Date, ErrorMessage = "the field {0} must be a valid value")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "the field {0} is not a valid e-mail")]
        public string Email { get; set; }
    }
}
