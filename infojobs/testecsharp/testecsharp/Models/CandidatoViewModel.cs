using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testecsharp.Models
{
    public class CandidatoViewModel 
    {
       
        public int IdCandidato { get; set; }

        [StringLength(50, ErrorMessage = "Numero de caracteres suportados(50)")]
        public string Nome { get; set; }

        [StringLength(150, ErrorMessage = "Numero de caracteres suportados(150)")]
        public string Sobreome { get; set; }

        [Display(Name = "Dt. Aniversário")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public string Aniversario { get; set; }

        [StringLength(250, ErrorMessage = "Numero de caracteres suportados(250)")]
        public string Email { get; set; }

        [Display(Name = "Dt. de Ingresso")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public DateTime DataIngresso { get; set; }

        [Display(Name = "Dt. Ult. Alteracao")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public DateTime? DataUltimaAlteracao { get; set; }

        public ICollection<ExperienciaCandidatoViewModel> Experiencias { get; set; }
    }
}
