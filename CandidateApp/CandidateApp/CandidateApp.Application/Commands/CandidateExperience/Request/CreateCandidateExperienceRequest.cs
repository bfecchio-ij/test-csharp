using CandidateApp.Application.Commands.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateApp.Application.Commands.Requests
{
    public class CreateCandidateExperienceRequest : IRequest<bool>
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Company { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Job { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(4000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CandidateId { get; set; }


        public CreateCandidateExperienceRequest(Guid CandidateId)
        {
            this.CandidateId = CandidateId;
            this.BeginDate =  DateTime.Now;
            this.EndDate = DateTime.Now;
        }

    }
}
