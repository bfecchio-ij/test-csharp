using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Projeto.Golnich.Domain.Candidatos
{
    public class Candidatos
    {
        public Candidatos()
        {
            Experiencias = new HashSet<Experiencias.Experiencias>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCandidato { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public DateTime DataCad{ get; set; }
        public DateTime DataAtu { get; set; }

        public virtual ICollection<Experiencias.Experiencias> Experiencias { get; set; }

    }
}
