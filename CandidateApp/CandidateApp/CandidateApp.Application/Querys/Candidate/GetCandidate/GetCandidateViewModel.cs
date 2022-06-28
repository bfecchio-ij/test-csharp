using CandidateApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateApp.Application.Querys.CandidateExperience
{
    public class GetCandidateExperienceViewModel
    {
        public Guid Id { get; set; }

        public string Company { get; private set; }

        public string Job { get; private set; }

        public string Description { get; private set; }

        public decimal Salary { get; private set; }

        public DateTime BeginDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public Guid CandidateId { get; private set; }
    }
}
