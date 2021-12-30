using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Candidato
    {       
        public int IdCandidato { get; set; }

        [StringLength(50)]
        [Required]
        public string Nome { get; set; }

        [Required]
        [StringLength(150)]
        public string Sobreome { get; set; }

        [Required]
        public string Aniversario { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        public DateTime DataIngresso { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public ICollection<ExperienciaCandidato> Experiencias { get; set; }
    }
}

