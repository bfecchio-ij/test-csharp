using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Golnich.RH.Models
{
    public class CandidatoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Ds_Data { get; set; }
        public string Email { get; set; }
        public bool IsSucess { get; set; }
        public string MensagemCallBack { get; set; }
        public Object Erros { get; set; }

    }
}
