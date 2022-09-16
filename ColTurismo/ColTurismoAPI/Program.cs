using AutoMapper;
using ColTurismoAPI.Data;
using ColTurismoAPI.Helpers;
using ColTurismoAPI.Servicios;
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
builder.Services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosLocal>();
builder.Services.AddHttpContextAccessor();




//Add AutoMapper profiles
builder.Services.AddSingleton(_ => new MapperConfiguration(
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


app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();   
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});



app.MapControllers();

app.Run();
