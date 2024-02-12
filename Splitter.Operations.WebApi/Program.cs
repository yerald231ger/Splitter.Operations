using System.IO.Compression;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Splitter.Operations.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging(builder => builder.AddConsole());

builder.Services.AddCors(builder =>
{
    builder.AddPolicy("SplitterFront", policy =>
    {
        policy.WithOrigins("http://localhost:4321")
            .AllowAnyHeader()
            .AllowAnyMethod();

        policy.WithOrigins("https://spliter-eight.vercel.app")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });

});

builder.Services.AddDbContext<SplitterDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SplitterDb");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("SplitterFront");

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapPost("/api/tableevent", async (EventTableDto dto, SplitterDbContext splitterDbContext, ILogger<Program> logger) =>
{
    try
    {
        var eventtable = new EventTable
        {
            Name = dto.name,
            Content = dto.content,
        };

        var result = splitterDbContext.EventTables.Add(eventtable);        
        await splitterDbContext.SaveChangesAsync();

        return Results.Created($"/api/tableevent/{result.Entity.Id}", result.Entity);
    }
    catch (Exception e)
    {
        logger.LogError(e, "Error while adding EventTable");
        throw;
    }
})
.Produces(201, responseType: typeof(EventTable))
.WithOpenApi();

app.MapGet("/api/tableevent", (SplitterDbContext splitterDbContext, ILogger<Program> logger) =>
{
    try
    {
        var eventtables = splitterDbContext.EventTables.ToList();
        logger.LogInformation("EventTables: {count}", eventtables.Count);
        return eventtables;
    }
    catch (Exception e)
    {
        logger.LogError(e, "Error while getting EventTable");
        throw;
    }
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
