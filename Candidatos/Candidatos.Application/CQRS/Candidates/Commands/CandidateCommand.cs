using Candidatos.Domain.Entities;
using MediatR;
using System;

namespace Candidatos.Application.CQRS.Candidates.Commands
{
    public abstract class CandidateCommand: IRequest<Candidate>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}
