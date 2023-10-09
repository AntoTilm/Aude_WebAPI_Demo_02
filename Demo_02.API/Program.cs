using Demo_02.BLL.Interfaces;
using Demo_02.BLL.Services;
using Demo_02.DAL.Interfaces;
using Demo_02.DAL.Repositories;
using Microsoft.Data.SqlClient;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Injections :
// - SQL
builder.Services.AddTransient<DbConnection>(service =>
{
    string connectionString = builder.Configuration.GetConnectionString("Default");
    return new SqlConnection(connectionString);
});
// - BLL
// On injecte le IngredientService qui devra correspondre à l'interface IIngredientService
builder.Services.AddScoped<IIngredientService, IngredientService>();
// - DAL
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
