﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_1API.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Proyecto_1APIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proyecto_1APIContext") ?? throw new InvalidOperationException("Connection string 'Proyecto_1APIContext' not found.")));

// Add services to the container.

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

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

/*app.MapControllerRoute(
    name: "medicByIdNumber",
    pattern: "Medic/id_number/{id_number}",
    defaults: new { controller = "Medics", action = "GetMedicsByIdNumber" });*/

app.MapControllers();

app.Run();
