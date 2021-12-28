using AutoMapper;
using InfoJobs.Dtos;
using InfoJobs.Models;

namespace InfoJobs.Helpers
{
    public class InfoJobsProfile : Profile
    {


        public InfoJobsProfile()
        {


            CreateMap<CandidateExperiencesRequestDto, CandidateExperiencesDto>();

            CreateMap<CandidateExperiences, CandidateExperiencesDto>();


            CreateMap<CandidatesRequestDto, CandidatesDto>();

            CreateMap<CandidateExperiences, CandidateExperiencesRequestDto>().ReverseMap();

            CreateMap<Candidates, CandidatesRequestDto>().ReverseMap();
            CreateMap<Candidates, CandidatesDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.Name} {src.Surname}"))
                .ForMember(
                dest => dest.Age,
                opt => opt.MapFrom(src => src.Birthday.GetCurrentAge()));








        }



    }
}
