using AutoMapper;
using CandidateApp.Application.Querys.Candidate;
using CandidateApp.Application.Querys.CandidateExperience;
using CandidateApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Candidate, GetCandidateViewModel>();

            CreateMap<Candidate, GetAllCandidatesViewModel>();
            CreateMap<CandidateExperience, GetCandidateExperienceViewModel>();
        }
    }
}
