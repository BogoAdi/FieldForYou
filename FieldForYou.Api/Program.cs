using Application;
using Domain.Interfaces;
using FieldForYou.Api.Dto;
using Infrastructure.DataAccess;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Marker));
builder.Services.AddAutoMapper(typeof(UserGetDto));

var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<FieldForYouContext>(options => options.UseSqlServer(cs));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISportFieldRepository, SportFieldRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
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
