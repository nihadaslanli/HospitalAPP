using FluentValidation.AspNetCore;
using FluentValidation;
using HospitalAPP1.DLL.Data;
using HospitalAPP.Dtos.DepartmentDtos;
using HospitalAPP.Dtos.DepartmentDtos;
using HospitalAPP.Profiles;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HospitalAPP1.DLL.Context>(opt =>
{
    opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<DepartmentCreateDtoValidator>();

builder.Services.AddFluentValidationRulesToSwagger();


builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfile(new MapProfile(new HttpContextAccessor()));
});

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
