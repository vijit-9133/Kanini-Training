using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PracticeOne.Application.Interface;
using PracticeOne.Domain;
using PracticeOne.Infrastructure.Repository;
using PracticeOne.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PracticeOne.Data.PlayerSportDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddScoped<IPlayer, PlayerRepo>();
builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<ISport, SportRepo>();
builder.Services.AddScoped<SportService>();

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
