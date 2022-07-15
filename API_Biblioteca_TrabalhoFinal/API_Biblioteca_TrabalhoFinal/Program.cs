using API_Biblioteca_TrabalhoFinal.Data;
using API_Biblioteca_TrabalhoFinal.Data.Repository;
using API_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));
// Vai buscar connection string para ligar a SQL

builder.Services.AddScoped<IRepositoryLeitores, RepositoryLeitores>();
builder.Services.AddScoped<IRepositoryObras, RepositoryObras>();
builder.Services.AddScoped<IRepositoryRequisicoes, RepositoryRequisicoes>();
builder.Services.AddScoped<IRepositoryNucleos, RepositoryNucleos>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
