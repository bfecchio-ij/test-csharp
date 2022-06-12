﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Candidatos.Application.DTO
{
    public class CandidateExperienceCommandDTO
    {
        [Key]
        public int IdCandidateExperience { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [MaxLength(100, ErrorMessage = "the field {0} must be between {1} and {2} characters")]
        public string Company { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [MaxLength(100, ErrorMessage = "the field {0} must be between {1} and {2} characters")]
        public string Job { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [MaxLength(4000, ErrorMessage = "the field {0} must be between {1} and {2} characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public int IdCandidate { get; set; }
    }
}