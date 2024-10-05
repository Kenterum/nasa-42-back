using CelestialOrreryApp.Data;
using CelestialOrreryApp.Data.Interfaces;
using CelestialOrreryApp.Data.Repositories;
using CelestialOrreryApp.Services;
using CelestialOrreryApp.Services.Interfaces;
using CelestialOrreryApp.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICelestialObjectRepository, CelestialObjectRepository>(); // Add repository
builder.Services.AddScoped<ICelestialObjectService, CelestialObjectService>();
builder.Services.AddSingleton<DataSeeder>();

// Register MongoDbContext correctly
builder.Services.AddSingleton<MongoDbContext>(sp =>
    new MongoDbContext(sp.GetRequiredService<IConfiguration>()));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed Data
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await seeder.SeedDataAsync();
}

// Swagger and API setup
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Celestial Orrery API V1");
        c.RoutePrefix = string.Empty; // Swagger will be available at the root URL.
    });
}

app.UseAuthorization();
app.MapControllers();
app.Run();
