using ManytoManyWithoutJunction.Data;
using ManytoManyWithoutJunction.Interfaces;
using ManytoManyWithoutJunction.Models;
using ManytoManyWithoutJunction.Repository;
using ManytoManyWithoutJunction.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DocPatDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));

builder.Services.AddScoped<DocRepo>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
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
