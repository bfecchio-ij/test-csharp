using AutoMapper;
using Candidatos.Application.CQRS.Candidates.Commands;
using Candidatos.Application.CQRS.CandidatesExperience.Commands;
using Candidatos.Application.DTO;
using Candidatos.Domain.Entities;

namespace Candidatos.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CandidateDTO, CandidateCreateCommand>().ReverseMap();
            CreateMap<CandidateDTO, CandidateUpdateCommand>().ReverseMap();
            CreateMap<CandidateDTO, CandidateRemoveCommand>().ReverseMap();

            CreateMap<CandidateExperienceCommandDTO, CandidateExperienceCreateCommand>().ReverseMap();
            CreateMap<CandidateExperienceCommandDTO, CandidateExperienceUpdateCommand>().ReverseMap();
            CreateMap<CandidateExperienceCommandDTO, CandidateExperienceRemoveCommand>().ReverseMap();


            CreateMap<CandidateDTO, Candidate>().ReverseMap();
            CreateMap<CandidateExperienceDTO, CandidateExperience>().ReverseMap();
            CreateMap<CandidateExperienceCommandDTO, CandidateExperience>().ReverseMap();
        }
    }
}
