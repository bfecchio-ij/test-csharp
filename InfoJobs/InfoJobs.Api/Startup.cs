using InfoJobs.Domain.Handlers.Candidates;
using InfoJobs.Domain.Handlers.Experiences;
using InfoJobs.Domain.Interfaces;
using InfoJobs.Infra.Data.Contexts;
using InfoJobs.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace InfoJobs.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            // Adding CORS
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    }
                );
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IJ.Api", Version = "v1" });
            });

            // Connecting DB
            services.AddDbContext<InfoJobsContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
                options.HttpsPort = 5001;
            });

            // Dependencies Injection:
            #region Candidates
            services.AddTransient<ICandidateRepository, CandidateRepository>();

            // Commands:
            services.AddTransient<CreateCandidateHandle, CreateCandidateHandle>();
            services.AddTransient<DeleteCandidateHandle, DeleteCandidateHandle>();
            services.AddTransient<UpdateCandidateHandle, UpdateCandidateHandle>();

            // Queries:
            services.AddTransient<ListCandidateHandle, ListCandidateHandle>();
            services.AddTransient<SearchCandidateByIdHandle, SearchCandidateByIdHandle>();
            services.AddTransient<SearchCandidateByEmailHandle, SearchCandidateByEmailHandle>();
            #endregion

            #region Experiences
            services.AddTransient<IExperienceRepository, ExperienceRepository>();

            // Commands:
            services.AddTransient<CreateExperienceHandle, CreateExperienceHandle>();
            services.AddTransient<DeleteExperienceHandle, DeleteExperienceHandle>();
            services.AddTransient<UpdateExperienceHandle, UpdateExperienceHandle>();

            // Queries:
            services.AddTransient<ListExperienceHandle, ListExperienceHandle>();
            services.AddTransient<SearchExperienceByIdHandle, SearchExperienceByIdHandle>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IJ.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
