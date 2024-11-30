using Microsoft.EntityFrameworkCore;
using VShop.ProdutoApi.Context;
using AutoMapper;
using VShop.ProdutoApi.Repositorios;
using VShop.ProdutoApi.Servicos;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;
using VShop.ProdutoApi;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var mySqlConnection = builder.Configuration.GetConnectionString("localhost");
var mySqlConnection = builder.Configuration.GetConnectionString("cloudaws");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(mySqlConnection,ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();


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


