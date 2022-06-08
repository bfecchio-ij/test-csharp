using CandidateManagemente.Application.Commands;
using CandidateManagemente.Domain.Interface;
using CandidateManagemente.Infra.Data;
using CandidateManagemente.Infra.Data.Repositories;
using CandidateManagemente.Web.Mapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

#region MediatR
builder.Services.AddMediatR(typeof(AddCandidateCommand));
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
#endregion
#region Mapper
builder.Services.AddAutoMapper(typeof(CandidateProfile));
#endregion
#region dbConect
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<DataContext>(options => options.
UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Candidate}/{action=Index}/{id?}");

app.Run();
