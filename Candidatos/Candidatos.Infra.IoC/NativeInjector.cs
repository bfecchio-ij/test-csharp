using Candidatos.Application.Implementations;
using Candidatos.Application.Interfaces;
using Candidatos.Application.Mappings;
using Candidatos.Domain.Interfaces.Repositories;
using Candidatos.Domain.Interfaces.Services;
using Candidatos.Domain.Services;
using Candidatos.Infra.Data.Context;
using Candidatos.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Candidatos.Infra.IoC
{
    public class NativeInjector
    {
        public static void RegisterApp(IServiceCollection service)
        {
            service.AddScoped<ICandidateAppService, CandidateAppService>();
            service.AddScoped<ICandidateService, CandidateService>();
            service.AddScoped<ICandidateRepository, CandidateRepository>();

            service.AddScoped<ICandidateExperienceAppService, CandidateExperienceAppService>();
            service.AddScoped<ICandidateExperienceService, CandidateExperienceService>();
            service.AddScoped<ICandidateExperienceRepository, CandidateExperienceRepository>();

            service.AddScoped<JobContext>();

            service.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
