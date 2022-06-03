global using test_CSharp.Data;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using test_CSharp.Interfaces;
using test_CSharp.Interfaces.Repositories;
using test_CSharp.Interfaces.Services;
using test_CSharp.Repositories;
using test_CSharp.Services;
using test_CSharp.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//Fluent validation
builder.Services.AddControllers().AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CandidateValidator>());
builder.Services.AddControllers().AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CandidateExperienceValidator>());
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// DbContext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Services

builder.Services.AddTransient<ICandidateRepository, CandidateRepository>();
builder.Services.AddTransient<ICandidateExperienceRepository, CandidateExperienceRepository>();

//Add Repositories

builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<ICandidateExperienceService, CandidateExperienceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
