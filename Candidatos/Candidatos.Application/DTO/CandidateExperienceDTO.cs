using System;
using System.ComponentModel.DataAnnotations;

namespace Candidatos.Application.DTO
{
    public class CandidateExperienceDTO
    {
        [Key]
        public int IdCandidateExperience { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [MaxLength(100, ErrorMessage = "the field does not have a valid format")]
        public string Company { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [MaxLength(100, ErrorMessage = "the field does not have a valid format")]
        public string Job { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [MaxLength(4000, ErrorMessage = "the field does not have a valid format")]
        public string Description { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [DataType(DataType.Currency, ErrorMessage = "the field {0} must be a valid currency")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [DataType(DataType.Date, ErrorMessage = "the field {0} must be a valid value")]
        public DateTime? BeginDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "the field {0} must be a valid value")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public int IdCandidate { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string CandidateName { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string CandidateSurname { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [DataType(DataType.Date, ErrorMessage = "the field {0} must be a valid value")]
        public DateTime CandidateBirthDate { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "the field {0} is not a valid e-mail")]
        public string CandidateEmail { get; set; }
    }
}
