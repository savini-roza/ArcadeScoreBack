using ArcadeScore.Contexts;
using ArcadeScore.Repositories;
using ArcadeScore.Repositories.Interfaces;
using ArcadeScore.Services;
using ArcadeScore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
        });
});

builder.Services.AddDbContext<InMemoryDbContext>();

builder.Services.AddTransient<IJogadorService, JogadorService>();
builder.Services.AddTransient<IPontuacaoService, PontuacaoService>();
builder.Services.AddTransient<IPontuacaoRepository, PontuacaoRepository>();
builder.Services.AddTransient<IJogadorRepository, JogadorRepository>();

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

app.UseCors();

app.Run();
