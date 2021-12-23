using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Projeto.Golnich.Domain.Experiencias
{
    public class Experiencias
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdExperiencia { get; set; }
        public int IdCandidato { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public string Descricao { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataSaida { get; set; }
        public DateTime DataCad { get; set; }
        public DateTime DataAtu { get; set; }
        [ForeignKey("IdCandidato")]
        public virtual Candidatos.Candidatos CandidatosNav { get; set; }

        public virtual string Nome_Candidato { get; set; }
    }
}
