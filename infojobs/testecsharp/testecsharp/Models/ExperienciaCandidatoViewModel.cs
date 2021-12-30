using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testecsharp.Models
{
    public class ExperienciaCandidatoViewModel
    {
        public int IdExperienciaCandidato { get; set; }

        [Required]
        public int IdCandidato { get; set; }

        [StringLength(100, ErrorMessage = "Numero de caracteres suportados(100)")]
        public string Empresa { get; set; }

        [StringLength(100, ErrorMessage = "Numero de caracteres suportados(100)")]
        public string Cargo { get; set; }

        [StringLength(4000, ErrorMessage = "Numero de caracteres suportados(4000)")]
        public string DescricaoCargo { get; set; }

        public decimal Salario { get; set; }

        [Display(Name = "Dt. de Início")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Dt. de Encerramento")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public DateTime? DateEncerramento { get; set; }


        [Display(Name = "Dt. de Ingresso")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public DateTime DataIngresso { get; set; }

        [Display(Name = "Dt. Ult. Alteracao")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public DateTime? DataUltimaAlteracao { get; set; }

        public ExperienciaCandidatoViewModel Experiencias { get; set; }
    }
}
