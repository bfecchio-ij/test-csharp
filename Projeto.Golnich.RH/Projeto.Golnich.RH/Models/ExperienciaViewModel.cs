using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Golnich.RH.Models
{
    public class ExperienciaViewModel
    {
        public int IdExperiencia { get; set; }
        public int IdCandidato { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public string Descricao { get; set; }
        public Decimal Salario { get; set; }
        public string DS_Salario { get; set; }
        public string DS_MinSalario { get; set; }
        public string DS_MaxSalario { get; set; }
        public bool Atual { get; set; }
        public DateTime DataInicio { get; set; }
        public string DS_DataInicio { get; set; }
        public DateTime? DataFinal { get; set; }
        public string DS_DataFinal { get; set; }
        public bool IsSucess { get; set; }
        public string MensagemCallback { get; set; }
        public Object Erros { get; set; }

    }
}
