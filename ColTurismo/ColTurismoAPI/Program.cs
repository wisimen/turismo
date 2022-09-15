using AutoMapper;
using ColTurismoAPI.Data;
using ColTurismoAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiColTurismo", Version = "v1" })
);
//Add AutoMapper profiles
builder.Services.AddSingleton(provider => new MapperConfiguration(
    cfg => cfg.AddProfile(new AutoMapperProfiles())
    ).CreateMapper());
//Add Db
builder.Services.AddDbContext<ColTurismoContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ColTurismoDB")
        )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
