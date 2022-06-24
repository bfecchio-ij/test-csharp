using InfoJobs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoJobs.Web.Models
{
    public class CandidateViewModel
    {
        public CandidateViewModel() { }

        public CandidateViewModel(Guid id, string name, string surname, DateTime birthDate, string email, DateTime insertDate, DateTime modifyDate)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Email = email;
            InsertDate = insertDate;
            ModifyDate = modifyDate;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }

        // Compositions
        public List<CandidateExperience> _experiences { get; set; }
        private IReadOnlyCollection<CandidateExperience> Experiences { get { return _experiences; } }
    }
}
