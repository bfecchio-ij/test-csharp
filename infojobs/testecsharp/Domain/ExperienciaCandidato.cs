using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ExperienciaCandidato
    {
        [Key]
        public int IdExperienciaCandidato { get; set; }

        public int IdCandidato { get; set; }

        [Required]
        [StringLength(100)]
        public string Empresa { get; set; }

        [Required]
        [StringLength(100)]
        public string Cargo { get; set; }

        [Required]
        [StringLength(4000)]
        public string DescricaoCargo { get; set; }

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Salario { get; set; }

        
        public DateTime DataInicio { get; set; }

        public DateTime? DateEncerramento { get; set; }

        public DateTime DataIngresso { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public Candidato Candidato { get; set; }
    }
}
