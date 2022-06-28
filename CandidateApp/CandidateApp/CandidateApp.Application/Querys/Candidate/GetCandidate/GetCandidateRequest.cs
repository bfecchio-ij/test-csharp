using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateApp.Application.Querys.Candidate
{
    public class GetCandidateRequest : IRequest<GetCandidateViewModel>
    {
        public Guid Id { get; set; }
    }
}
