using Splitter.Operations.WebApi;
using Splitter.Operations;
using Splitter.Operations.Models;
using Splitter.Operations.Data.SqlServer;
using Splitter.Operations.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEventTableService()
    .AddData()
        .AddSqlServer(builder.Configuration);

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("SplitterFront");

app.MapPost("/api/tableevent", async (EventTableDto dto, SplitterDbContext splitterDbContext, EventTableServices eventTableServices,
ILogger<Program> logger) =>
{
    try
    {

        var eventTable = await eventTableServices.CreateEvent(dto.name);
        await splitterDbContext.SaveChangesAsync();

        return Results.Created($"/api/tableevent/{eventTable.Id}", eventTable);
    }
    catch (Exception e)
    {
        logger.LogError(e, "Error while adding EventTable");
        throw;
    }
})
.Produces(201, responseType: typeof(EventTable))
.WithOpenApi();

app.MapGet("/api/tableevent", async (SplitterDbContext splitterDbContext, ILogger<Program> logger, 
IEventTableRepository eventTableRepository) =>
{
    try
    {
        var eventtables = await eventTableRepository.GetAsync();
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