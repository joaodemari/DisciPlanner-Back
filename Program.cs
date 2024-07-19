using BackEnd_DisciPlanner.Data;
using BackEnd_DisciPlanner.Repositories.Implementations;
using BackEnd_DisciPlanner.Repositories.Interfaces;
using BackEnd_DisciPlanner.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<GetGradeByAlunoService>();
builder.Services.AddTransient<IGradeRepository, GradeRepository>();
builder.Services.AddDbContext<DisciPlannerDbContext>(options =>
{
    options.UseSqlite("FileName=./Data/DisciPlanner.db");
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

app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
});

app.Run();
