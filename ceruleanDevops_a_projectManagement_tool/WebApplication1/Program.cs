using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using BusinessLOgic.sevices;
using DAL.Dbcontext;
using DAL.Irepositeries;
using DAL.repositeries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 
builder.Services.AddAuthorization();
builder.Services.AddScoped<IWorkItemServices, WorkItems_Services>();
builder.Services.AddScoped<IWorkItemsRespository, WorkItemRepository>();
builder.Services.AddScoped<WorkItemsDbContext>();
builder.Services.AddAutoMapper(typeof(Program));

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
