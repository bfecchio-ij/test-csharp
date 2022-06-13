using Candidatos.Application.Implementations;
using Candidatos.Application.Interfaces;
using Candidatos.Domain.Interfaces;
using Candidatos.Infra.Data.Context;
using Candidatos.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Candidatos.Infra.IoC
{
    public class NativeInjector
    {
        public static void RegisterApp(IServiceCollection service)
        {
            service.AddScoped<ICandidateService, CandidateService>();
            service.AddScoped<ICandidateRepository, CandidateRepository>();

            service.AddScoped<ICandidateExperienceService, CandidateExperienceService>();
            service.AddScoped<ICandidateExperienceRepository, CandidateExperienceRepository>();

            var myHandlers = AppDomain.CurrentDomain.Load("Candidatos.Application");
            service.AddMediatR(myHandlers);

            service.AddAutoMapper(AppDomain.CurrentDomain.Load("Candidatos.Application"));
        }
    }
}
