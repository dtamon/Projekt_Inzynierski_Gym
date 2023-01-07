using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Projekt_Inzynierski.Core.Services.Interfaces;
using Projekt_Inzynierski.Core.Services.Services;
using Projekt_Inzynierski.Core.Validators;
using Projekt_Inzynierski.DataAccess.Context;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Repositories;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;
using Projekt_Inzynierski.DataAccess.Repositories.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Context
builder.Services.AddDbContext<GymDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

//Repositories 
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IGroupTrainingRepository, GroupTrainingRepository>();
builder.Services.AddScoped<ISpecializationRepository, SpecializationRepository>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
builder.Services.AddScoped<ITrainingEquipmentRepository, TrainingEquipmentRepository>();
builder.Services.AddScoped<IVisitRepository, VisitRepository>();

//Services
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ISpecializationService, SpecializationService>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<ITrainingEquipmentService, TrainingEquipmentService>();
builder.Services.AddScoped<IVisitService, VisitService>();

//Automapper
builder.Services.AddAutoMapper(typeof(Projekt_Inzynierski.Core.GymMappingProfile).Assembly);

//Validation
builder.Services.AddFluentValidationAutoValidation(config =>
{
    config.DisableDataAnnotationsValidation = true;
})
    .AddValidatorsFromAssemblyContaining<EmployeeValidator>();

//Authentication
builder.Services.AddScoped<IPasswordHasher<Client>, PasswordHasher<Client>>();
builder.Services.AddScoped<IPasswordHasher<Employee>, PasswordHasher<Employee>>();
builder.Services.AddScoped<IPasswordHasher<Trainer>, PasswordHasher<Trainer>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
