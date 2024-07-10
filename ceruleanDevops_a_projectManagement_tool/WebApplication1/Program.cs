using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using BusinessLOgic.sevices;
using DAL.Dbcontext;
using DAL.Irepositeries;
using DAL.repositeries;
using Microsoft.EntityFrameworkCore;

/*var builder = WebApplication.CreateBuilder(args);*/
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddAuthorization();
 
builder.Services.AddScoped<IWorkItemServices, WorkItems_Services>();
builder.Services.AddScoped<IWorkItemsRespository, WorkItemRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IIterationRepository, IterationRepository>();
builder.Services.AddScoped<IIterationService, IterationService>();
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserSerivce,User_Sevices>();
builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IFileService, FileUploadService>();
builder.Services.AddScoped<IWorkItemLinkRepository, WorkItemLinkRepository>();
builder.Services.AddScoped<IWorkItemLinkService, WorkItemLinkService>();
builder.Services.AddScoped<IcommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService,Comments_sevices>();
builder.Services.AddScoped<IPriorityRepository,PriorityRepository>();
builder.Services.AddScoped<IPriorityService,PriorityService>();
builder.Services.AddScoped<ITypeRepository, TypeRepository>();
builder.Services.AddScoped<ITypeService, TypeService>();
builder.Services.AddScoped<WorkItemsDbContext>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                      });
});
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("MyAllowSpecificOrigins");
app.UseAuthorization();
 

app.MapControllers();

app.Run();
