using FluentValidation;
using FluentValidation.AspNetCore;
using HospitalAPP.DLL.Data;
using HospitalAPP.Dtos.DepartmentDtos;
using HospitalAPP.Profiles;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HospitalAPPContext>(opt =>
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
