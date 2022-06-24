using InfoJobs.Domain.Handlers.Candidates;
using InfoJobs.Domain.Handlers.Experiences;
using InfoJobs.Domain.Interfaces;
using InfoJobs.Infra.Data.Contexts;
using InfoJobs.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoJobs.Web
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
            services.AddControllersWithViews();

            services.AddDbContext<InfoJobsContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDistributedMemoryCache();
            //services.AddScoped(typeof(ICandidateRepository), typeof(CandidateRepository));
            //services.AddScoped(typeof(IExperienceRepository), typeof(ExperienceRepository));

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(2);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Adding Swagger
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "InfoJobs", Version = "v2" });
            });

            // Dependencies Injection:
            #region Candidates
            services.AddTransient<ICandidateRepository, CandidateRepository>();
            services.AddTransient<CreateCandidateHandle, CreateCandidateHandle>();
            services.AddTransient<DeleteCandidateHandle, DeleteCandidateHandle>();
            services.AddTransient<UpdateCandidateHandle, UpdateCandidateHandle>();
            services.AddTransient<ListCandidateHandle, ListCandidateHandle>();
            services.AddTransient<SearchCandidateByIdHandle, SearchCandidateByIdHandle>();
            services.AddTransient<SearchCandidateByEmailHandle, SearchCandidateByEmailHandle>();
            #endregion

            #region Experiences
            services.AddTransient<IExperienceRepository, ExperienceRepository>();
            services.AddTransient<CreateExperienceHandle, CreateExperienceHandle>();
            services.AddTransient<DeleteExperienceHandle, DeleteExperienceHandle>();
            services.AddTransient<UpdateExperienceHandle, UpdateExperienceHandle>();
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
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "InfoJobs");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
